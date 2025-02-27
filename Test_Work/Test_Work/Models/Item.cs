namespace Test_Work.Models
{
    public class Item
    {
        public int id { get; set; }
        public string? model { get; set; }
        public int ipAdress { get; set; }
        public int macAdress { get; set; }
        public string? adminVLAN { get; set; }
        public int serialNumber { get; set; }
        public int inventaryNumber { get; set; }
        public DateTime buyDate { get; set; }
        public DateTime installDate { get; set; }
        public int floor { get; set; }
        public string? comment { get; set; }
    }
}
