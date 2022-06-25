using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PromoProjectCCAI.Dtos
{
    public class PromoDto : ValidationAttribute
    {
        [Key]
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
        [Display(Name = "End Promo"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }
        public IFormFile Item { get; set; }
        public string StoreID { get; set; }
        public List<StoreDto> Stores { get; set; }
        public SelectList? PromoTypeList { get; set; }
        public SelectList? ValueTypeList { get; set; }
    }
}
