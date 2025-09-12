using DashboardWS.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conex�o com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o do CORS para fazer requisi��e com Vue local 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:8080",
                                     "http://localhost:5173", "http://127.0.0.1:5500") // porta da aplica��o Vue
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configurar o pipeline de requisi��es HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();