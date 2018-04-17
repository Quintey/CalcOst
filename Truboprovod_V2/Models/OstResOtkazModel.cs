using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Truboprovod_V2.Models
{
    public class OstResOtkazModel
    {
        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = " вероятность прогноза(%) - ")]
        [Range(75, 99, ErrorMessage = "75% - 99%")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Prognoz { get; set; }


        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число  или используется точка вместо запятой.")]
        [Display(Name = " наружный диаметр трубы или детали трубопровода(м) - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Diametr { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = "номинальная толщина стенки - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string TolshinaStenki { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = "наработка на момент последнего диагностирования - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Narabotka { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = "количество элементов трубопровода - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Elements { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = "погонная длина трубопровода - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Dlinna { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = "число разрушившихся на момент диагностирования элементов трубопровода - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string BrokenEl { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Display(Name = "средняя скорость износа стенки - ")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string SkorostIznosa { get; set; }

        [Display(Name = "результат")]
        public string result { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "тип трубопровода - ")]
        public string serovodorod { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "коэф. надежности по назначению трубопроводов - ")]
        public string Yn { get; set; }

       // [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Категория трубопровода - ")]
        public string m2 { get; set; }


        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "коэф. надежности по нагрузке - ")]
        public string Yf { get; set; }

        //[RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        //[Display(Name = "коэф. условий работы трубопроводов, транспортирующих сероводород. продукты - ")]
        //public string Ys { get; set; }

       // [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Характеристика труб - ")]
        public string Harakterisika { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "рабочее давление в трубопроводе - ")]
        public string P { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "нормативное сопротивление, равное наименьшему значению временного сопротивления разрыву материала труб - ")]
        public string R1 { get; set; }

        [RegularExpression(@"^[0-9,]+$", ErrorMessage = "Необходимо число или используется точка вместо запятой.")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = " нормативное сопротивление, равное наименьшему значению предела текучести при растяжении, сжатии и изгибе материала труб - ")]
        public string R2 { get; set; }



    }
}
