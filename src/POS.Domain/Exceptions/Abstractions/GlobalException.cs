namespace POS.Domain.Exceptions.Abstractions
{
    public abstract class GlobalException : Exception
    {
        protected GlobalException(string message) : base(message)
        {
        }
    }
}
