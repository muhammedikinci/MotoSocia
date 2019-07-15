namespace Application
{
    public abstract class Command
    {
        protected IMotoDBContext context { get; set; }
        protected object Data { get; set; }

        public Command (IMotoDBContext context, object Data)
        {
            this.Data = Data;
            this.context = context;
        }

        public abstract void Execute();
    }
}
