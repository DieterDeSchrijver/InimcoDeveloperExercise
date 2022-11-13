using InimcoDeveloperExercise.CosmosDB.Repositories;
using InimcoDeveloperExercise.IRepositories;
using InimcoDeveloperExercise.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

var url = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("URL");
var primaryKey = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("PrimaryKey");
var dbName = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("DatabaseName");
var containerName = builder.Configuration.GetSection("AzureCosmosDbSettings")
    .GetValue<string>("ContainerName");

var cosmosClient = new CosmosClient(
    url,
    primaryKey
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<InimcoUserService>(options => new InimcoUserService());
builder.Services.AddSingleton<IInimcoUserCosmosRepository>(options => new InimcoUserCosmosRepository(cosmosClient, dbName, containerName));
builder.Services.AddSingleton<ISocialAccountTypeCosmosRepository>(options => new SocialAccountTypeCosmosRepository(cosmosClient, dbName, containerName));

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();