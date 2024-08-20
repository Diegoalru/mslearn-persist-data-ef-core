using ContosoPizza.Data;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;
var connectionStringPizza = config.GetConnectionString("PizzaContext");
var connectionStringPromotions = config.GetConnectionString("PromotionsContext");

builder.Services.AddDbContext<PizzaContext>(options => options.UseSqlite(connectionStringPizza));
builder.Services.AddDbContext<PromotionsContext>(options => options.UseSqlite(connectionStringPromotions));

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.MapGet("/", () => @"Contoso Pizza management API. Navigate to /swagger to open the Swagger test UI.");

app.Run();
