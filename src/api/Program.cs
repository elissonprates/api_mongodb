using aplicacao;
using repositorio;
using Microsoft.Extensions.Options;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection(nameof(DatabaseConfig)));
builder.Services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

builder.Services.AddSingleton<IRepositorioDeEquipamento, RepositorioDeEquipamento>();
builder.Services.AddSingleton<PrimeiroServico, PrimeiroServico>();



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

/*INICIO DA CONFIGURAÇÃO - PROMETHEUS*/
// Custom Metrics to count requests for each endpoint and the method
var counter = Metrics.CreateCounter("webapimetric", "Counts requests to the WebApiMetrics API endpoints",
    new CounterConfiguration
    {
        LabelNames = new[] { "method", "endpoint" }
    });

app.Use((context, next) =>
{
    counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
    return next();
});

// Use the prometheus middleware
app.UseMetricServer();
app.UseHttpMetrics();

/*FIM DA CONFIGURAÇÃO - PROMETHEUS*/

app.Run();