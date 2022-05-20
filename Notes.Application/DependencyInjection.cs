using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Notes.Commands.CreateNote;
using System.Reflection;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<CreateNoteCommandValidating>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
