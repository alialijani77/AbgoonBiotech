using AbgoonBiotech.Application.Helpers;
using AbgoonBiotech.Domain.Entities.UserManagement;
using AbgoonBiotech.Infra.Data.UserManagement.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("UserManagement");

builder.Services.AddScoped(_ => { return BaseUserManagementContext.CreateInstance(connectionString, null); });
builder.Services.AddIdentity<User, Role>(options =>
{
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
})
		.AddErrorDescriber<FaCustomIdentityErrorDescriber>()
		.AddEntityFrameworkStores<BaseUserManagementContext>()
		.AddDefaultTokenProviders();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
