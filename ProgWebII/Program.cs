using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProgWebII.Auxiliares;
using ProgWebII.Infra;
using ProgWebII.Repositorios;
using ProgWebII.Seguranca;
using ProgWebII.Servicos;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Chat API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<ContextoBanco>(options => options.UseSqlServer("Server=localhost;Database=ProgWebII;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient(typeof(IServicoBase<>), typeof(ServicoBase<>));

builder.Services.AddTransient(typeof(IUsuarioRepositorio), typeof(UsuarioRepositorio));
builder.Services.AddTransient(typeof(IAutenticacaoServico), typeof(AutenticacaoServico));

TokenServico.Initialize(builder.Configuration);

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Secret"));
builder.Services.AuthenticationConfigure(key);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
