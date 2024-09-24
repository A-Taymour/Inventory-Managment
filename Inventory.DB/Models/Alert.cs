public class Alert
{
    public int AlertID { get; set; }
    public DateTime AlertDate { get; set; }
    public string Description { get; set; }
    public bool IsResolved { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }
}
