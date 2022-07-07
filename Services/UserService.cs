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

namespace ConsignmentApi.Services;

public class UserService
{
    private readonly IMongoCollection<User> users;

    public UserService(IOptions<ConsignmentFormDatabaseSettings> configuration)
    {
        var client = new MongoClient(configuration.Value.ConnectionString);

        var database = client.GetDatabase(configuration.Value.DatabaseName);

        users = database.GetCollection<User>("User");
    }

    public List<User> GetUsers() => users.Find(user => true).ToList();

    public User GetUser(string id) => users.Find<User>(user => user.Id == id).FirstOrDefault();

    public User Create(User user)
    {
        users.InsertOne(user);
        return user;
    }
}