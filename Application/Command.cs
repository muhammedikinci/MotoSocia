namespace Application
{
    public abstract class Command
    {
        protected DataTransport DataObject { get; set; }

        public Command (DataTransport dataObject)
        {
            DataObject = dataObject;
        }

        public abstract void Execute();
    }
}
