using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kreta.Shared.Responses
{
    public class RepositoryResponse : ErrorStore
    {
        public bool IsSuccess => !HasError;
        public RepositoryResponse() : base() { }
        public RepositoryResponse(string errorString) : base()
        {
            Error = errorString;
        }
    }
}
