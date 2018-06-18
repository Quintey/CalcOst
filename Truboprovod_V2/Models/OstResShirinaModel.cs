using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Truboprovod_V2.Models
{
    public class OstResShirinaModel
    {

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число  или используется точка вместо запятой.")]
        [Display(Name = " наружный диаметр трубы или детали трубопровода(мм) - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public double Diametr { get; set; }


        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "рабочее давление в трубопроводе(Па) - ")]
        public double P { get; set; }


        /// <summary>
        /// коэф m2
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Транспортируемая среда - ")]
        public string Sreda { get; set; }

        [Display(Name = "результат")]
        public string OstResult { get; set; }

        /// <summary>
        /// время эксплуатации трубопровода, лет.
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "время эксплуатации трубопровода(лет) - ")]
        public double Narabotka { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Материал труб - ")]
        public string Material { get; set; }

        /// <summary>
        /// Tn - Номинальная толщина стенки
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Номинальная толщина стенки(мм) - ")]
        public double Nominal_tolshina { get; set; }


       [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Марка стали - ")]
        public string Steel { get; set; }

        public int Rh1 { get; set; }
        public int Rh2 { get; set; }
        public string UserName { get; set; }

        public string Date { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

    }
}