using Application.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ICommander
    {
        void Execute<TCommandType, T>(T data) where TCommandType : ICommand;
        object[] GetResult();
        TCommandType GetInstance<TCommandType>();
    }
}
