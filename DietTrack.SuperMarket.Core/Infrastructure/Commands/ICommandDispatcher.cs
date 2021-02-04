using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Core.Infrastructure
{
    public interface ICommandDispatcher
    {
        Task Dispatch(ICommand command);
    }
}
