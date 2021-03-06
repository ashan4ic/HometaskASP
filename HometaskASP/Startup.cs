using HomataskASP.DataAccess;
using HometaskASP.Domain;
using HometaskASP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskASP
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Host=localhost;Port=5432;Database=Mydb;Username=postgres;Password=n7vwfn5twF";
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.AddControllers();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserDomain, UserDomain>();
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
