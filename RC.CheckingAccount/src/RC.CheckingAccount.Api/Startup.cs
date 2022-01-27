using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RC.CheckingAccount.Api.Extensions;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.CommandsHandlers;
using RC.CheckingAccount.Domain.Events;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;
using RC.CheckingAccount.Repository.Context;
using RC.CheckingAccount.Repository.Respositories;
using RC.CheckingAccount.Repository.UoW;
using RC.Core.Bus;

namespace RC.CheckingAccount.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCustomSwagger();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IRequestHandler<CreateClientCommand, bool>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, bool>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClientCommand, bool>, ClientCommandHandler>();
            //services.AddScoped<IEventStore, SqlEventStore>();


            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<CheckingAccountContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCustomSwagger();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
