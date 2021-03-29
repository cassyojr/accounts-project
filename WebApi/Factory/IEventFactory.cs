namespace Accounts.Project.Factory
{
    public interface IEventFactory
    {
        /// <summary>
        /// Create an instance of the factory to deposit, transfer or withdraw from account
        /// </summary>
        /// <param name="eventType">Event type to execute on account</param>
        /// <returns>
        /// An instance of EventConcretion based on the event type informed
        /// </returns>
        EventConcretion Create(string eventType);
    }
}
