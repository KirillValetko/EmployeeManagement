using EmployeeManagement.Web.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InitDbContext(builder.Configuration);
builder.Services.InitRepositories();
builder.Services.InitServices();
builder.Services.InitHelpers();
builder.Services.InitProviders();
builder.Services.InitMapper();
builder.Services.InitJwt(builder.Configuration);
builder.Services.InitValidation();
builder.Services.InitSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
