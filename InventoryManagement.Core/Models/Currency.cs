using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models
{
    [Table("Currency", Schema = "parameters")]
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
