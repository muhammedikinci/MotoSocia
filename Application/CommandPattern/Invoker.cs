namespace Application.CommandPattern
{
    public class Invoker
    {
        readonly Command mCommand;

        public Invoker(Command command)
        {
            mCommand = command;
        }

        public void Execute ()
        {
            mCommand.Execute();
        }
    }
}
