using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirinaCalc
{
    
    public class Class1
    {
        /// <summary>
        /// коэффициент условий работы материала труб при разрыве, равный 0,8;
        /// </summary>
        public static double  m1 = 0.8;

        /// <summary>
        /// коэффициент условий работы материала труб при повышенных
        /// температурах, для условий работы промысловых трубопроводов
        /// принимается равным 1;
        /// </summary>
        
        public static double m3 = 1;
        /// <summary>
        /// коэффициент однородности материала труб: для бесшовных труб из
        /// углеродистой и для сварных труб из низколегированной ненормализованной
        /// стали k1 = 0,8, для сварных труб из углеродистой и для сварных труб из
        /// нормализованной низколегированной стали k1 = 0,85.
        /// </summary>
        public static double[] k1 = new double[ 2] {0.8 ,  0.85 };

                /// <summary>
        /// R1 - расчетное сопротивление материала труб и деталей трубопроводов, Па
        ///// </summary>
        //public static double RasSopr(double Rh1, double m1,double m2, double k1)
        //{
        //    double val = Rh1 * m1 * m2 * k1;
        //    return  val;
        //} 

        public static double SrOtkl(double Tsr, int count, List<double> DynamicExtraField)
        {
            double sum = 0;

            for (int j = 0; j < DynamicExtraField.Count; j++)
            {

                sum = sum + Math.Pow((DynamicExtraField[j] - Tsr), 2);

            }
           return  Math.Sqrt(sum / (count - 1));
        }

        public static double Tmin(double Tsr, int count, List<double> DynamicExtraField)
        {
            return Tsr - 2 * SrOtkl(Tsr, count,DynamicExtraField);
        }
        
        public static double Totbr(double Rh1, double Rh2 ,double P, double Dh, double Sreda_double, string Material)
        {
           
            double val_k1 = 0;
            
            switch (Material)
            {
                case "1":
                    val_k1 = k1[0];
                    break;

                case "2":
                    val_k1 = k1[1];
                    break;
                
            }
            double R1 = 0;
            double check = (Rh2 * m3) / (Rh1 * Sreda_double);

            if (check >= 0.75)
            {
                R1 = (Rh1 * m1 * Sreda_double * val_k1);
                return ((1.2 * P * 1 * Dh) / (2 * (R1 + 1.2 * P)))*1000;
            }
            else
                return ((1.2 * P * 1 * Dh) / (2 * (0.9 * Rh2 * m3 + 1.2 * P)))*1000;


        }


        public static double SrSkorostKorozii(double Nominal_tolshina, double Narabotka, double Tsr, int count, List<double> DynamicExtraField)
        {


            return (Nominal_tolshina - Tmin(Tsr,count,DynamicExtraField)) / Narabotka;
        }

        /// <summary>
        /// Расчёт остаточного ресурса
        /// трубопровода по минимальной
        /// вероятной толщине стенки труб по
        /// результатам диагностики
        /// </summary>
        public static double OstResurs(List<double> DynamicExtraField, double Sreda_double, string Material,
                                                        double Nominal_tolshina, double P, double Diametr,
                                                                     double Rh1, double Rh2, double Narabotka, int count, double Tsr )
        {
            return  (Tmin(Tsr,count,DynamicExtraField)-Totbr(Rh1,Rh2,P,Diametr, Sreda_double, Material)) / 
                                        SrSkorostKorozii(Nominal_tolshina,Narabotka,Tsr,count,DynamicExtraField);
        }



    }
}
