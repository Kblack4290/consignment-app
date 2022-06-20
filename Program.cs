using ConsignmentApi.Models;
using ConsignmentApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsImplementationPolicy", builder => builder.WithOrigins("*"));
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCorsImplementationPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
