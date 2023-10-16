using Amazon;
using EmployeeManagement.Web.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureAwsSecretsManager();
builder.Services.InitDbContext(builder.Configuration, builder.Environment);
builder.Services.InitRepositories();
builder.Services.InitServices();
builder.Services.InitHelpers();
builder.Services.InitProviders();
builder.Services.InitMapper();
builder.Services.InitJwt(builder.Configuration);
builder.Services.InitValidation();
builder.Services.InitSwagger();
builder.Services.InitAwsLambda(builder.Environment);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
