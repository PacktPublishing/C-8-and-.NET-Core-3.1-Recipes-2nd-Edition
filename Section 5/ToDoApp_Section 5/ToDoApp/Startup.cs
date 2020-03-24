using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoApp.Data;
using ToDoApp.Services;
using AutoMapper;
using ToDoApp.DTO;
using ToDoApp.Models;

namespace ToDoApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            int taskTimeout = Configuration.GetValue<Int32>("TaskTimeout");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ToDoApp")));

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddSingleton<ConfigurationService>();
            services.AddTransient<IToDosService, TodosService>();
            services.AddSingleton<Mapper>(MapProperties());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected Mapper MapProperties()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateToDoDTO, Todo>(MemberList.Source);
                config.CreateMap<Todo, CreateToDoDTO>();

                config.CreateMap<ChangeToDoStatusDTO, Todo>(MemberList.Source);
            });
            return new Mapper(config);
        }
    }
}
