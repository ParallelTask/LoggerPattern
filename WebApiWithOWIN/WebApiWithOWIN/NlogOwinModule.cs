using System.Linq;
using Autofac;
using Autofac.Core;
using Microsoft.Owin.Logging;
using NLog.Owin.Logging;

namespace WebApiWithOWIN
{
    public class NLogOwinModule : Module
    {
        private readonly NLogFactory _logFactory = new NLogFactory();

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            registration.Preparing += RegistrationOnPreparing;
        }

        private void RegistrationOnPreparing(object sender, PreparingEventArgs preparingEventArgs)
        {
            preparingEventArgs.Parameters = preparingEventArgs.Parameters.Union(new Parameter[]
            {
                new ResolvedParameter(
                    (p, i) => p.ParameterType == typeof(ILogger),
                    (p, i) =>
                    {
                        var loggerName = p.Member.DeclaringType.FullName;
                        // If the parameter being injected has its own logger attribute, then promote its name value instead as the logger name to use.
                        // Return a new Logger instance for injection, parameterised with the most appropriate name which we have determined above.
                        return _logFactory.Create(loggerName);
                    }),
                new TypedParameter(typeof(ILogger), _logFactory.Create("Something")),

            });
        }
    }
}