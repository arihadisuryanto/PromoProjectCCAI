using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoProjectCCAI.Models
{
    public class PromoModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Promo ID")]
        public string PromoID { get; set; }
        [StringLength(30)]
        [Display(Name = "Promo Description")]
        public string PromoDescription { get; set; }
        [Display(Name = "Promo Type")]
        public string PromoType { get; set; }
        [Display(Name = "Value Type")]
        public string ValueType { get; set; }
        [Display(Name = "Value")]
        public long Value { get; set; }
        [Display(Name = "Start Promo"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }
        public string StoreID { get; set; }
    }
}
