using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NSubstitute;
using SlackConnector.Client;

namespace ZwapgridReviewBot.Tests
{
    public abstract class TestsBase
    {
        readonly IWindsorContainer _container;

        protected TestsBase()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.Containing<ISlackClient>());
        }

        protected T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        protected T RegisterSubstituteFor<T>(T instance = null) where T : class
        {
            _container.Register(Component.For<T>().Instance(instance ?? Substitute.For<T>()).Named(Guid.NewGuid().ToString()).IsDefault());
            return Resolve<T>();
        }

        protected T SubstituteFor<T>() where T : class
        {
            return Substitute.For<T>();
        }
    }
}