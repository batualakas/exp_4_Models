using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="Bu Alanı Doldurmak Zorunludur")]
        //[StringLength(15,ErrorMessage ="En fazla 15 Karakter girebilir")]
        [MaxLength(15, ErrorMessage = "En fazla 15 Karakter girebilirsiniz")]
        [MinLength(3, ErrorMessage = "En az 3 Karakter girmelisiniz")]
        public string CategoryName { get; set; }

        [DisplayName("Kategorinin Açıklaması")]
        [Required(ErrorMessage ="Bu alanı doldurmak zorunludur")]
        public string Description { get; set; }
    }
}