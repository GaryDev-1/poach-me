namespace WildlifePoaching.API.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base() { }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
