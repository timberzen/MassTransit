namespace MassTransit
{
    using Azure.ServiceBus.Core.Configuration;
    using Azure.ServiceBus.Core.Saga;
    using Saga;


    public static class MessageSessionSagaRepositoryConfigurationExtensions
    {
        /// <summary>
        /// Configures the saga to use the Azure Service Bus session for saga persistence.
        /// </summary>
        /// <param name="configurator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ISagaRegistrationConfigurator<T> MessageSessionRepository<T>(this ISagaRegistrationConfigurator<T> configurator)
            where T : class, ISaga
        {
            configurator.Repository(x => x.RegisterSagaRepository(provider => new MessageSessionSagaRepository<T>()));

            return configurator;
        }

        /// <summary>
        /// Use the Azure Service Bus session saga repository for sagas configured by type (without a specific generic call to AddSaga/AddSagaStateMachine)
        /// </summary>
        /// <param name="configurator"></param>
        public static void SetMessageSessionSagaRepositoryProvider(this IRegistrationConfigurator configurator)
        {
            configurator.SetSagaRepositoryProvider(new MessageSessionSagaRepositoryRegistrationProvider());
        }
    }
}
