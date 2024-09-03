namespace Web.Api.Common
{
    public class Result
    {
        public Result(bool isSuccess, Error error, ErrorType? errorType)
        {
            IsSuccess = isSuccess;
            Error = error;
            ErrorType = errorType;
        }
        public bool IsSuccess { get; private set; }
        public Error Error { get; private set; }
        public ErrorType? ErrorType { get; private set; }

        public bool IsFailure => !IsSuccess;
        
        public static Result Success()
        {
            return new Result(true, Error.None, null);
        }
        public static Result Failure(Error error, ErrorType errorType)
        {
            return new Result(false, error, errorType);
        }

        public static Result<TValue> Success<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, Error.None, null!);
        }

        public static Result<TValue> Failure<TValue>(Error error, ErrorType errorType)
        {
            return new Result<TValue>(default!, false, error, errorType);
        }
    }

    public class Result<TValue> : Result
    {
        public TValue Value { get; private set; }
        public Result(TValue value, bool isSuccess, Error error, ErrorType? errorType) 
            : base(isSuccess, error, errorType)
        {
           Value = value;
        }
    
    }


    public static class ResultExtensions
    {
        public static T Match<T>(this Result result, Func<T> onSuccess, Func<Error, T> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Error);
        }
    }
}
