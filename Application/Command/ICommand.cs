namespace Application.Command
{
    public interface ICommand
    {
        void Execute();
        object[] Result();
    }
}
