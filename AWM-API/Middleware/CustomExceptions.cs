using usermanagement_api.Enums;

namespace usermanagement_api.Middleware
{
    public class CustomException : Exception
    {
        public ErrorCodeEnum ErrorCode { get; }

        public CustomException(string message, ErrorCodeEnum errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
