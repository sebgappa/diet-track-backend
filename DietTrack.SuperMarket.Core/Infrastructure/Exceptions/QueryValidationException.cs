using System;
using System.Collections.Generic;
using System.Text;

namespace DietTrack.SuperMarket.Core.Infrastructure.Exceptions
{
    public class QueryValidationException : Exception
    {
        public QueryValidationException() : base($"Validation on query failed")
        {

        }
    }
}
