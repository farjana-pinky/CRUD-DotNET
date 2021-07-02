using System.ComponentModel.DataAnnotations;

namespace InternCrudApiTask.Models
{
    public class ColdDrink
    {
        [Key]
        public int intColdDrinksId { get; set; }
        public string strColdDrinksName { get; set; }
        public decimal numQuantity { get; set; }
        public decimal numUnitPrice { get; set; }
    }
}
