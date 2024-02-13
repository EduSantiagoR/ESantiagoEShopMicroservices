namespace VentaService.Models
{
    public class Result
    {
        public bool Correct { get; set; }
        public string Message { get; set; }
        public object Objeto { get; set; }
        public List<object> Objects { get; set; }
        public Exception Ex { get; set; }
    }
}
