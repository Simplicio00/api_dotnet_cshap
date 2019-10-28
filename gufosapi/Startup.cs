using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace gufosapi
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
        services.AddControllersWithViews().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>{
            options.TokenValidationParameters = new TokenValidationParameters{
                ValidateIssuer = true,  //Habilita a validação do issue do token
                ValidateAudience = true, //Habilita a validação do audience do token
                ValidateLifetime = true, //Habilita a validação do tempo de expiração do token 
                ValidateIssuerSigningKey = true, //Permite que a microsoft valide o token
                ValidIssuer = Configuration["Jwt:Issuer"], //Define um valor válido para um issuer
                ValidAudience = Configuration["Jwt:Issuer"], // Define um valor válido para o audience
                // Issuer Signing key será igual ao resultado de SymmetricSecurityKey recebendo a JWT key criptografada
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:key"]))
            };
        }); //Fim jtw

         services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                // Mostrar o caminho dos comentários dos métodos Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }



        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

               // Habilitamos efetivamente o Swagger em nossa aplicação.
            app.UseSwagger();
            // Especificamos o endpoint da documentação
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });



        }
 }
}