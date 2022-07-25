using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Exceptions
{
    public class AlreadyExistsFailureException : Xeption
    {
        public AlreadyExistsFailureException(Exception innerException) :
            base(message: "Failure with same Id already exists",
                innerException)
        { }
    }
}
