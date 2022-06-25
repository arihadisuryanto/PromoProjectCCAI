using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoProjectCCAI.Models
{
    public class ItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public string PromoID { get; set; }
        [ForeignKey(nameof(PromoID))]
        public PromoModel Promos { get; set; }
        public string ItemName { get; set; }

    }
}
