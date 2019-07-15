namespace Application.CommandPattern
{
    public abstract class Command
    {
        protected IMotoDBContext Context { get; set; }
        protected object Data { get; set; }

        public Command (IMotoDBContext context, object Data)
        {
            this.Data = Data;
            this.Context = context;
        }

        public abstract void Execute();
    }
}
