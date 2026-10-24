namespace Domain.Models;

public class Stock_movements
{
    public int Id { get; set; }
    public int Product_Id { get; set; }
    public int Change_qty { get; set; }
    public DateTime Moved_at { get; set; } = DateTime.Now;
}
