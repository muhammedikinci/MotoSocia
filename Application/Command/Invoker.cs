namespace Application.Command
{
    public class Invoker<T> where T : ICommand
    {
        private T target;

        public Invoker(T target)
        {
            this.target = target;
        }

        public void Invoke()
        {
            target.Execute();
        }
    }
}
