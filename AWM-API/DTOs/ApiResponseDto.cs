namespace AWM_API.DTOs
{
    public class ApiResponseDto<T>
    {
        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Provides additional details about the response or errors.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The data payload of the response, if applicable.
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// An optional property to include any error codes for failed operations.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// An optional list of validation or other error details.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApiResponseDto()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// Factory method for a successful response.
        /// </summary>
        public static ApiResponseDto<T> SuccessResponse(T data, string message = "Operation completed successfully.")
        {
            return new ApiResponseDto<T>
            {
                Success = true,
                Message = message,
                Result = data
            };
        }

        /// <summary>
        /// Factory method for a failure response.
        /// </summary>
        public static ApiResponseDto<T> FailureResponse(string message, string errorCode = null, List<string> errors = null)
        {
            return new ApiResponseDto<T>
            {
                Success = false,
                Message = message,
                ErrorCode = errorCode,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
