namespace Lab.Mediator.ValidationExample.Core.Exceptions
{
    /// <summary>
    /// Utilizada para tratar falhas em validações de entidades, comandos, dtos, etc.
    /// </summary>
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
