using LibyanaHub.Services.Infrastructure.Data;
using LibyanaHub.Services.Infrastructure.IRepository;
using LibyanaHub.Services.Infrastructure.Repository;
using static LibyanaHub.Services.WebApi.Helper.SwaggerExampleSchema;









var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Transient);



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen(c =>
{
	c.SchemaFilter<PostMessageExampleSchemaFilter>();
});


// Database Interface

builder.Services.AddScoped<IDbUnitOfWork, DbUnitOfWork>();



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

app.MapControllers();

app.MapHealthChecks("/healthz");


app.Run();
