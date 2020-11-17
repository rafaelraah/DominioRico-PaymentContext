using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    /*Só pode manipular um ICommand*/
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}