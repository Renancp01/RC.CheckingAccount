using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RC.CheckingAccount.Api.Extensions;
using RC.CheckingAccount.Application.AutoMapper;
using RC.CheckingAccount.Application.Interfaces;
using RC.CheckingAccount.Application.Services;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Commands.Credit;
using RC.CheckingAccount.Domain.Commands.Debit;
using RC.CheckingAccount.Domain.CommandsHandlers;
using RC.CheckingAccount.Domain.EventHandlers;
using RC.CheckingAccount.Domain.Events.Client;
using RC.CheckingAccount.Domain.Events.Core;
using RC.CheckingAccount.Domain.Events.Credit;
using RC.CheckingAccount.Domain.Events.Debit;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;
using RC.CheckingAccount.Repository.Context;
using RC.CheckingAccount.Repository.EventSourcing;
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
            services.AddControllers()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                    // x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
            services.AddCustomSwagger();
            services.AddMediatR(typeof(Startup));
            services.AddHttpContextAccessor();
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());

            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<CreateClientEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<UpdateClientEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<RemoveClientEvent>, ClientEventHandler>();

            services.AddScoped<INotificationHandler<CreateCreditEvent>, CreditEventHandler>();
            services.AddScoped<INotificationHandler<UpdateCreditEvent>, CreditEventHandler>();
            services.AddScoped<INotificationHandler<RemoveCreditEvent>, CreditEventHandler>();

            services.AddScoped<INotificationHandler<CreateDebitEvent>, DebitEventHandler>();
            services.AddScoped<INotificationHandler<UpdateDebitEvent>, DebitEventHandler>();
            services.AddScoped<INotificationHandler<RemoveDebitEvent>, DebitEventHandler>();

            //services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<IRequestHandler<CreateClientCommand, bool>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, bool>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClientCommand, bool>, ClientCommandHandler>();

            services.AddScoped<IRequestHandler<CreateDebitCommand, bool>, DebitCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDebitCommand, bool>, DebitCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDebitCommand, bool>, DebitCommandHandler>();

            services.AddScoped<IRequestHandler<CreateCreditCommand, bool>, CreditCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCreditCommand, bool>, CreditCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCreditCommand, bool>, CreditCommandHandler>();

            services.AddScoped<IEventStore, SqlEventStore>();

            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<ICreditAppService, CreditAppService>();
            services.AddScoped<IDebitAppService, DebitAppService>();


            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDebitRepository, DebitRepository>();
            services.AddScoped<ICreditRepository, CreditRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddDbContext<CheckingAccountContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<CheckingAccountContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
