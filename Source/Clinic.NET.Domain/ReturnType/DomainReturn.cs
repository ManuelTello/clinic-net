namespace Clinic.NET.Domain.ReturnType
{
    public class DomainReturn<T>
    {
        public T? ResponseData { get; private set; }

        public List<string> ErrorsList { get; private set; }

        public bool IsSuccess { get; private set; }

        public DomainReturn(T? responseData, List<string> errorMessage, bool isSuccess = false )
        {
            this.ResponseData = responseData;
            this.ErrorsList = errorMessage;
            this.IsSuccess = isSuccess;
        }
    }
}