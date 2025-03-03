using BookingSystem.Middleware;
using BookingSystem.Models.Requests;
using BookingSystem.Services;
using BookingSystem.Services.Abstract;
using BookingSystem.Storage.Abstract;
using BookingSystem.Storage.Concrete;
using BookingSystem.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IMemoryStore, MemoryStore>();
builder.Services.AddScoped<IManagerFactory, ManagerFactory>();
builder.Services.AddScoped<IRequestValidator<SearchRequest>, SearchRequestValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
        opt.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
