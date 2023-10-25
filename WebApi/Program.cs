using Domain.Interfaces.Generics;
using Domain.Interfaces.IAula;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuario;
using Domain.Servicos;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ContextBase>();

// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceAula, RepositorioAula>();
builder.Services.AddSingleton<InterfaceUsuario, RepositorioUsuario>();


// SERVIÇO DOMINIO
builder.Services.AddSingleton<IAulaServico, AulaServico>();
builder.Services.AddSingleton<IUsuarioServico, UsuarioServico>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Teste.Securiry.Bearer",
                     ValidAudience = "Teste.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var Client = "http://192.168.1.100:4200";
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(Client)); 

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
