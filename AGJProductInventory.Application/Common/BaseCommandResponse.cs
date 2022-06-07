namespace AGJProductInventory.Application.Common
{
    public class BaseCommandResponse<T>
    {
        public T Data { get; set; }
        public DateTime Time { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
