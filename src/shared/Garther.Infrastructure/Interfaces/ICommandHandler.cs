namespace Garther.Infrastructure.Interfaces;

public interface ICommand { }

public interface ICommandHandler<in TCommand, TCommandResult>
    where TCommand : ICommand
{
    Task<TCommandResult> Send(TCommand command, CancellationToken token);
}