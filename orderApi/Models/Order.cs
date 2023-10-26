using orderApi.Models.Shared;
namespace orderApi.Models
{
	public class Order:EntityBase
	{
        public int CustomerId { get; set; }
        public HashSet<int> ProductId { get; set; } = new HashSet<int>();
       

    }
}
