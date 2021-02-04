using DietTrack.SuperMarket.Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Core.Domain.Foods.Commands.Handlers
{
    public class SaveFoodCommandHandler : ICommandHandler<SaveFoodCommand>
    {
        public Task HandleAsync(SaveFoodCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
