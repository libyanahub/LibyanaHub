using LibyanaHub.Services.DataAccess.Data;
using LibyanaHub.Services.DataAccess.IRepository;
using LibyanaHub.Services.DataAccess.Repository;
using static LibyanaHub.Services.WebApi.Helper.SwaggerExampleSchema;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Transient);


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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
