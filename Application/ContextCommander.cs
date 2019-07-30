using Application.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ContextCommander : ICommander 
    {
        private ICommand command;
        private readonly IMotoDBContext _context;

        public ContextCommander(IMotoDBContext context)
        {
            _context = context;
        }

        public void Execute<TCommandType, T> (T entity) where TCommandType : ICommand
        {
            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), new object[] { _context, entity });

            Invoker<TCommandType> invoker = new Invoker<TCommandType>((TCommandType)command);
            invoker.Invoke();
        }

        public void Execute<TCommandType, T>(IList<T> entities) where TCommandType : ICommand
        {
            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), new object[] { _context, entities });

            Invoker<TCommandType> invoker = new Invoker<TCommandType>((TCommandType)command);
            invoker.Invoke();
        }

        public void ExecuteWithoutContext<TCommandType, T>(T entities) where TCommandType : ICommand
        {
            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), new object[] { entities });

            Invoker<TCommandType> invoker = new Invoker<TCommandType>((TCommandType)command);
            invoker.Invoke();
        }

        public void ExecuteWithoutContext<TCommandType, T>(IList<T> entities) where TCommandType : ICommand
        {
            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), new object[] { entities });

            Invoker<TCommandType> invoker = new Invoker<TCommandType>((TCommandType)command);
            invoker.Invoke();
        }

        public object[] GetResult()
        {
            return command.Result();
        }

        public TCommandType GetInstance<TCommandType>()
        {
            return (TCommandType)command;
        }
    }
}
