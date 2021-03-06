using ConsignmentApi.Models;
using ConsignmentApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsImplementationPolicy", builder =>
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});
builder.Services.Configure<ConsignmentFormDatabaseSettings>(
    builder.Configuration.GetSection("ConsignmentFormDatabase"));


builder.Services.AddSingleton<ConsignmentService>();

builder.Services.AddControllers()
.AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



// builder.Services.Configure<ConsignmentFormDatabaseSettings>(
//     builder.Configuration.GetSection("ConsignmentFormDatabase"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCorsImplementationPolicy");

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
