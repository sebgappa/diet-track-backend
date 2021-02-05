using System;

namespace DietTrack.SuperMarket.Core.Infrastructure.Exceptions
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException() : base($"Validation on command failed")
        {

        }
    }
}
