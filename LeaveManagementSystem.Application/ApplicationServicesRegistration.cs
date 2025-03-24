using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
