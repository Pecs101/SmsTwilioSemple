namespace SmsTwilioSemple.Helper.Dtos
{
    public class Response<T>
    {
        public bool status { get; set; }
        public int statusCode { get; set; }
        public string? message { get; set; }
        public T? data { get; set; }
    }
}
