using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoNoticias.Application.Aplicacoes;
using ProjetoNoticias.Application.Interfaces;
using ProjetoNoticias.Domain.Interfaces;
using ProjetoNoticias.Domain.Interfaces.Genericos;
using ProjetoNoticias.Domain.Interfaces.InterfaceServicos;
using ProjetoNoticias.Domain.Services;
using ProjetoNoticias.Entidades.Entidades;
using ProjetoNoticias.Infra.Configuracoes;
using ProjetoNoticias.Infra.Repositorio;
using ProjetoNoticias.Infra.Repositorio.Genericos;
using System;
using System.Threading.Tasks;
using WebAPI.Token;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(
            options => options.
            UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<Contexto>();

            //INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGenericos<>), typeof(RepositorioGenerico<>));
            services.AddSingleton<INoticia, RepositorioNoticia>();
            services.AddSingleton<IUsuario, RepositorioUsuario>();

            //SERVIÇO DOMINIO
            services.AddSingleton<IServiceNoticia, ServiceNoticia>();

            //INTERFACE APLICAÇÃO
            services.AddSingleton<IAplicacaoNoticia, AplicacaoNoticia>();
            services.AddSingleton<IAplicacaoUsuario, AplicacaoUsuario>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(option =>
       {
           option.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               //Aqui vai as alterações da empresa...
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
