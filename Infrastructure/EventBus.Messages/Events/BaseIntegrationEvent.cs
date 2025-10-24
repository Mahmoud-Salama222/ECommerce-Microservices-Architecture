namespace EventBus.Messages.Events
{
    public class BaseIntegrationEvent // class has all events so we can trach this event
    {
        private readonly Guid correlationId;

        public string CorrelationId { get; set; } // every event has id
        public DateTime CreationDate { get; set; }
        public BaseIntegrationEvent()
        {
            CorrelationId = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;


        }
        public BaseIntegrationEvent(Guid CorrelationId, DateTime CreationDate)
        {
            correlationId = CorrelationId;
            this.CreationDate = CreationDate;
        }
    }
}
