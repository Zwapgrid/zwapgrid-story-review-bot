using System.Reflection;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;

namespace SlackConnector.Configuration
{
     /// <summary>
    /// Used implicitly by Castle.Core infrastructure
    /// </summary>
    public class SlackConnectorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithConfig("log4net.xml"));

            container.Register(Classes
                .FromAssembly(Assembly.GetExecutingAssembly())
                .BasedOn<ITransientDependency>()
                .WithServiceDefaultInterfaces()
                .LifestyleTransient());
        }
    }

    public interface ITransientDependency
    {
    }
}