using Application.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ICommander
    {
        void Execute<TCommandType, T>(T data) where TCommandType : ICommand;
        void Execute<TCommandType, T>(IList<T> data) where TCommandType : ICommand;
        void ExecuteWithoutContext<TCommandType, T>(T data) where TCommandType : ICommand;
        void ExecuteWithoutContext<TCommandType, T>(IList<T> data) where TCommandType : ICommand;
        object[] GetResult();
        TCommandType GetInstance<TCommandType>();
    }
}
