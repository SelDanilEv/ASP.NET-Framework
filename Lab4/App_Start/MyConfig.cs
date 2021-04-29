namespace Lab4
{
    using Lab4.Repository;
    using Ninject.Modules;
    using Ninject.Web.Common;

    public class MyConfig : NinjectModule
    {
        public override void Load()
        {
            //ConfigurationManager.AppSettings.Get("RequestScope");

            //Bind<ITelephoneRepository>().To<TelephoneJSONRepository>();
            //Bind<ITelephoneRepository>().To<TelephoneJSONRepository>().InSingletonScope();
            //Bind<ITelephoneRepository>().To<TelephoneJSONRepository>().InThreadScope();
            //Bind<ITelephoneRepository>().To<TelephoneJSONRepository>().InRequestScope();

            //Bind<ITelephoneRepository>().To<TelephoneMSSqlRepository>().InTransientScope();
            Bind<ITelephoneRepository>().To<TelephoneMSSqlRepository>().InSingletonScope();
            //Bind<ITelephoneRepository>().To<TelephoneMSSqlRepository>().InThreadScope();
            //Bind<ITelephoneRepository>().To<TelephoneMSSqlRepository>().InRequestScope();
        }
    }
}