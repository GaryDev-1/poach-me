namespace WildlifePoaching.API.Models.Domain.Common
{
    public class ApiErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string DeveloperMessage { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }

        public ApiErrorResponse()
        {
            Errors = new Dictionary<string, string[]>();
        }
    }
}
