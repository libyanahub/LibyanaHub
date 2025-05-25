using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Application.Services;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.DbInitializer;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Infrastructure.Repository;
using LibyanaHub.Services.WebApi.Extensions;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static LibyanaHub.Services.WebApi.Helper.SwaggerExampleSchema;









var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(options => { });

//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//builder.Services.AddSingleton(mapper);


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers();


// Database Interface
builder.Services.AddScoped<IDbUnitOfWork, DbUnitOfWork>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddScoped<IUnitOfServices, UnitOfServices>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//	c.SchemaFilter<PostMessageExampleSchemaFilter>();
//});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	option.SchemaFilter<PostMessageExampleSchemaFilter>();
	option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference= new OpenApiReference
				{
					Type=ReferenceType.SecurityScheme,
					Id=JwtBearerDefaults.AuthenticationScheme
				}
			}, new string[]{}
		}
	});
});
builder.AddAppAuthetication();







var app = builder.Build();


// Configure the HTTP request pipeline.
bool enableSwagger = app.Environment.IsDevelopment() ||
					 builder.Configuration.GetValue<bool>("EnableSwaggerInProduction");

if (enableSwagger)
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



//app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthorization();

SeedDatabase();

app.MapControllers();

app.Run();




void SeedDatabase()
{
	using (var scope = app.Services.CreateScope())
	{
		IDbInitializer dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
		dbInitializer.Initialize();
	}
}