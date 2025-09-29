namespace Demo.Modules.Comman
{
    public class Response
    {
        public Response()
        {
            ResponseStatus = "Unkonwn"; ResponseMessage = "Success"; OtherMessage = ""; 
        }

        public string ResponseMessage { get; set; }
        public string OtherMessage { get; set; }
        public object ResponseObject { get; set; }
        public string ResponseStatus { get; set; }
        public bool ResponseFlag { get; set; }
    }
}
