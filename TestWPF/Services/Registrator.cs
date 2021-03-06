using Microsoft.Extensions.DependencyInjection;
using TestWPFApp.Services.Interfaces;
using TestWPFApp.Services.Students;

namespace TestWPFApp.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>(); //создается единожды при первом обращении
            // services.AddTransient<IDataService, DataService>(); //создается каждый раз при запросе
            //services.AddScoped<IDataService, DataService>();  //Создается в области Scope и очищается после ее уничтожения
            //Например так
            //using (var scope=App.Host.Services.CreateScope())
            //{
            //    var data = scope.ServiceProvider.GetRequiredService<IDataService>();
            //}
            services.AddTransient<IAsycDataService, AsycDataService>();
            services.AddTransient<IWebServerService, HttpListnerWebServer>();
            services.AddSingleton<StudentRepository>();
            services.AddSingleton<GroupRepository>();
            services.AddSingleton<StudentsManager>();
            services.AddTransient<IUserDialogService, WindowsUserDialogService>();

            return services;
        }
    }
}
