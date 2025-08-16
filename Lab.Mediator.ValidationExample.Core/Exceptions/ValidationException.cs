namespace Lab.Mediator.ValidationExample.Core.Exceptions
{
    public class ValidationException : LabExceptionBase
    {
        private IDictionary<string, string> _errors;    
        public ValidationException(IDictionary<string, string> errors)
        {
            _errors = errors;
        }

        public IDictionary<string, string> GetErrors()
        {
            return _errors;
        }
    }
}
