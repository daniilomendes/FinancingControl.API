namespace FinancialControl.Models.Response
{
    public class ApiResponse<T>
    {
        public bool IsSucess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public ApiResponse(bool isSucess, T? data, string? errorMessage)
        {
            IsSucess = isSucess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>(true, data, null);
        }

        public static ApiResponse<T> Failure(string errorMessage)
        {
            return new ApiResponse<T>(false, default, errorMessage);
        }
    }
}
