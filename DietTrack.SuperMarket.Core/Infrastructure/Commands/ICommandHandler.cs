using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Core.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
