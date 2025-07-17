using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProEventos.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Configuração do banco de dados (SQLite)
builder.Services.AddDbContext<ProEventosContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// 🔧 Controladores + CORS + Swagger
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer(); // Necessário para Swagger no novo modelo
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
});

var app = builder.Build();

// 🌐 Ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
}

// 🔒 HTTPS redirection
app.UseHttpsRedirection();

// 🌐 CORS
app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader();
});

// 🔐 Autorização (se usar autenticação depois)
app.UseAuthorization();

// 🚀 Rotas
app.MapControllers();

app.Run();
