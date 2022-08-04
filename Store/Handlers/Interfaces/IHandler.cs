using Store.Commands.Interfaces;

namespace Store.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}