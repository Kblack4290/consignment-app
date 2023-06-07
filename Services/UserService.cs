using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using ConsignmentApi.Models;
using ConsignmentApi.Controllers;
using ConsignmentApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace ConsignmentApi.Services;

public class UserService
{
    private readonly IMongoCollection<User> users;

    private readonly string? key;

    public class JwtSettings
    {
        public string? Key { get; set; }
    }
    public UserService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetSection("ConsignmentFormDatabase").GetValue<string>("ConnectionString"));

        var database = client.GetDatabase(configuration.GetSection("ConsignmentFormDatabase").GetValue<string>("DatabaseName"));

        users = database.GetCollection<User>(configuration.GetSection("ConsignmentFormDatabase").GetValue<string>("UserCollectionName"));

        var jwtSettings = configuration.GetSection("JWTSettings").Get<JwtSettings>();

        this.key = jwtSettings.Key;
    }

    public List<User> GetUsers() => users.Find(user => true).ToList();

    public User GetUser(string id) => users.Find<User>(user => user.Id == id).FirstOrDefault();


    public User Create(User user)
    {
        users.InsertOne(user);
        return user;
    }

    public string Authenticate(string email, string password)
    {
        var user = this.users.Find(x => x.Email == email && x.Password == password).FirstOrDefault();

        if (user == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenKey = Encoding.ASCII.GetBytes(key);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {

            Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Email, email),
            }),

            Expires = DateTime.UtcNow.AddHours(1),

            SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}