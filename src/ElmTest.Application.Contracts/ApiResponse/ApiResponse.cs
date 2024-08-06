namespace ElmTest.Application.Contracts.ApiResponse
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public T Data { get; set; }
        public bool IsSucceed { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public static ApiResponse<T> IsSuccess(T data, string message, string statusCode)
        {
            return new ApiResponse<T> { Message = message, StatusCode = statusCode, Data = data, IsSucceed = true, ValidationErrors = null };
        }
        public static ApiResponse<T> IsFailed(string message, string statusCode, IEnumerable<ValidationError> validationErrors = null)
        {
            return new ApiResponse<T> { Message = message, StatusCode = statusCode, IsSucceed = false, ValidationErrors = validationErrors };
        }
    }
}
