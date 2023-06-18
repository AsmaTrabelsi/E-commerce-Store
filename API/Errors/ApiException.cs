namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public string Deatils { get; set; } 
        public ApiException(int statusCode, string message = null, string deatils = null) : base(statusCode, message)
        {
            Deatils = deatils;
        }


    }
}
