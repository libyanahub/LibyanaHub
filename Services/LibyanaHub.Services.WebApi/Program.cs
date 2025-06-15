using LibyanaHub.Services.Application.IServices;
using LibyanaHub.Services.Application.Services;
using LibyanaHub.Services.Domain.Entities.Identity;
using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.DbInitializer;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Infrastructure.Repository;
using LibyanaHub.Services.Models.User;
using LibyanaHub.Services.WebApi.Extensions;
using LibyanaHub.Services.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;







var builder = WebApplication.CreateBuilder(args);

// 1) Controllers
builder.Services.AddControllers();


// Add your new exception handler service here
builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); // <--- ADD THIS
builder.Services.AddProblemDetails(); // <--- ADD THIS (Good practice to include)



// 2) EF Core
//builder.Services.AddDbContext<AppDbContext>(options => { });
builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Scoped);



// 3) JWT settings
builder.Services.Configure<JwtOptions>(
	builder.Configuration.GetSection("ApiSettings:JwtOptions"));

// 4) Identity with GUID keys
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();

// 5) Application services
builder.Services.AddHttpContextAccessor(); // For IHttpContextAccessor in services

builder.Services.AddScoped<IDbUnitOfWork, DbUnitOfWork>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfServices, UnitOfServices>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// 6) Swagger + JWT UI
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//	c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//	{
//		Name = "Authorization",
//		In = ParameterLocation.Header,
//		Type = SecuritySchemeType.ApiKey,
//		Scheme = "Bearer",
//		Description = "Enter: Bearer {your JWT token}"
//	});
//	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//	  {
//		new OpenApiSecurityScheme {
//		  Reference = new OpenApiReference {
//			Type = ReferenceType.SecurityScheme,
//			Id   = JwtBearerDefaults.AuthenticationScheme
//		  }
//		},
//		Array.Empty<string>()
//	  }
//	});
//});


builder.Services.AddSwaggerGen(c =>
{
	// جعل Swagger يستخدم الاسم الكامل مع النيم سبيس كـ SchemaId لتجنب التعارض
	c.CustomSchemaIds(type => type.FullName.Replace('+', '.'));

	// تعريف JWT Bearer Authentication في Swagger
	c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
	{
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		Description = "Enter 'Bearer' followed by your JWT token, e.g. \"Bearer abcdef12345\""
	});

	// إضافة متطلبات الأمان على كل endpoints
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = JwtBearerDefaults.AuthenticationScheme
				},
				Scheme = "Bearer",
				Name = "Authorization",
				In = ParameterLocation.Header
			},
			Array.Empty<string>()
		}
	});

	// باقي إعدادات Swagger إذا عندك...
});




// 7) **Only call your extension once** to hook up the Bearer scheme
builder.AddAppAuthetication();


//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//builder.Services.AddSingleton(mapper);



var app = builder.Build();

app.UseExceptionHandler(_ => { });

// 8) Pipeline
if (app.Environment.IsDevelopment() ||
	builder.Configuration.GetValue<bool>("EnableSwaggerInProduction"))
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// **Important**: Must call UseAuthentication before UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

// 9) Seed DB
using (var scope = app.Services.CreateScope())
{
	var init = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
	init.Initialize();
}



app.MapControllers();
app.Run();

SeedDatabase();


void SeedDatabase()
{
	using (var scope = app.Services.CreateScope())
	{
		IDbInitializer dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
		dbInitializer.Initialize();
	}
}