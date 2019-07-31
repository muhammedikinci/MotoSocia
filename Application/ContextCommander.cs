using Application.Command;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Application
{
    public class ContextCommander : ICommander 
    {
        private ICommand command;
        private readonly IMapper _mapper;
        private readonly IMotoDBContext _context;
        private Dependencies _dependencies;

        public ContextCommander(IMotoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _dependencies = new Dependencies()
            {
                Context = context,
                Mapper = mapper
            };
        }

        public void Execute<TCommandType, T> (T entity) where TCommandType : ICommand
        {
            Transport<T> transport = new Transport<T>()
            {
                Dependencies = _dependencies,
                Data = entity
            };

            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), transport);

            Invoker<TCommandType> invoker = new Invoker<TCommandType>((TCommandType)command);
            invoker.Invoke();
        }

        public void Execute<TCommandType, T>(IList<T> entities) where TCommandType : ICommand
        {
            Transport<T> transport = new Transport<T>()
            {
                Dependencies = _dependencies,
                DataList = entities
            };

            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), transport);

            Invoker<TCommandType> invoker = new Invoker<TCommandType>((TCommandType)command);
            invoker.Invoke();
        }

        public void Execute<TCommandType, T>(object[] datas) where TCommandType : ICommand
        {
            Transport<T> transport = new Transport<T>()
            {
                Dependencies = _dependencies,
                MultipleObjects = datas
            };

            command = (TCommandType)Activator.CreateInstance(typeof(TCommandType), transport);

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
