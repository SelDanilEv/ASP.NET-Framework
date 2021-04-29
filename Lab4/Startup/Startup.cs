namespace Lab4.Startup
{
    using Lab4.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITelephoneRepository, TelephoneMSSqlRepository>();
            return services.BuildServiceProvider();
        }
    }
}