using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalcLibrary
{
    public class Class1
    {

        //Значения коэффициентов условий работы трубопровода   m2
        //Таблица П.Б.2
        public static double[,] Koefs_m2 = new double[3, 2] {{ 1 , 0.6 },
                                                             { 2 , 0.75 },
                                                             { 3 , 0.90 }};


        //Значения коэффициентов γs условий работы трубопроводов, транспортирующих
        //сероводород содержащие продукты
        //Таблица П.Б.3
        // 1 столбец  - категория, 2 и 3 - содержание сероводорода (среднее | низкое)
        public static double[,] Koefs_Ys = new double[3, 3] {{ 1 , 0.4 , 0.5 },
                                                             { 2 , 0.5 , 0.6 },
                                                             { 3 , 0.6 , 0.65 }};


        //Значения коэффициентов надежности по материалу   γm
        //Таблица П.Б.4
        //Смотри примечание таблицы в документе !!!
        public static double[,] Koefs_Ym = new double[4, 2] {{ 1 , 1.34 },
                                                             { 2 , 1.40 },
                                                             { 3 , 1.47 },
                                                             { 4 , 1.55 }};










        // таблица квантилей 
        public static double[,] KvantilTable = new double[31, 2] {{ 0.75, 0.67 },
                                                                            { 0.76, 0.71 },
                                                                            { 0.77, 0.74 },
                                                                            { 0.78, 0.77 },
                                                                            { 0.79, 0.81 },
                                                                            { 0.80, 0.84 },
                                                                            { 0.81, 0.88 },
                                                                            { 0.82, 0.92 },
                                                                            { 0.83, 0.95 },
                                                                            { 0.84, 0.99 },
                                                                            { 0.85, 1.04 },
                                                                            { 0.86, 1.08 },
                                                                            { 0.86, 1.08 },
                                                                            { 0.87, 1.13 },
                                                                            { 0.88, 1.18 },
                                                                            { 0.89, 1.23 },
                                                                            { 0.90, 1.28 },
                                                                            { 0.91, 1.34 },
                                                                            { 0.92, 1.41 },
                                                                            { 0.93, 1.48 },
                                                                            { 0.94, 1.56 },
                                                                            { 0.95, 1.65 },
                                                                            { 0.96, 1.75 },
                                                                            { 0.97, 1.88 },
                                                                            { 0.98, 2.05 },
                                                                            { 0.99, 2.33 },
                                                                            { 0.993, 2.46 },
                                                                            { 0.995, 2.58 },
                                                                            { 0.997, 2.75 },
                                                                            { 0.998, 2.88 },
                                                                            { 0.999, 3.09 }};



        // функция интерполяции 
        public static double Interpolacia(double fX1, double fX2, double X1, double X2, double U)
        {

            return fX1 + (fX2 - fX1) * (U - X1) / (X2 - X1);

        }


        

        public static double Kvantil_Uq(double r, double delta, double L)
        {

            double a = 1 - ((r + 1) / (L / delta));

            bool check = false;
            double Result = 0;
            double previosElement, nextElement;

            for (int i = 0; i < 31; i++)
            {

                if (KvantilTable[i, 0] == (a))
                {
                    Result = KvantilTable[i, 1];

                    check = true;
                    break;

                }

            }


            if (check == false)
            {
                for (int i = 0; i < 29; i++)
                {
                    if (KvantilTable[i, 0] < (a) && (a) < KvantilTable[i + 1, 0])
                    {
                        previosElement = KvantilTable[i, 1];
                        nextElement = KvantilTable[i + 1, 1];

                        Result = Interpolacia(previosElement, nextElement, KvantilTable[i, 0], KvantilTable[i + 1, 0], (a));
                        break;
                    }
                }
            }


            return Result;

        }



        

        public static double Kvantil_Uy(double Veroyatnost, double r, double delta, double L)
        {

            double Uy = (0.01 * Veroyatnost) * (1 - ((r + 1) / (L / delta)));

            bool check = false;
            double Result = 0;
            double previosElement, nextElement;

            for (int i = 0; i < 31; i++)
            {

                if (KvantilTable[i, 0] == (Uy))
                {
                    Result = KvantilTable[i, 1];

                    check = true;
                    break;

                }

            }


            if (check == false)
            {
                for (int i = 0; i < 29; i++)
                {
                    if (KvantilTable[i, 0] < (Uy) && (Uy) < KvantilTable[i + 1, 0])
                    {
                        previosElement = KvantilTable[i, 1];
                        nextElement = KvantilTable[i + 1, 1];

                        Result = Interpolacia(previosElement, nextElement, KvantilTable[i, 0], KvantilTable[i + 1, 0], (Uy));
                        break;
                    }
                }
            }

            return Result;

        }


        


        public static double dopustIsnosStenki(double Yf,double P,double Dh, double caseR, double R2, double R1, double m2, double Ym, double Yn, double Ys,double Tn)
        {
            double R = 0;
            double res;
            switch (caseR)
            {

                case 222:
                    R = (R2 * Ys) / Yn;
                    break;

                case 1:
                    R = Math.Min(((R1 * m2) / (Ym * Yn)), ((R2 * m2) / (0.9 * Yn)));
                    break;
            };

            res = 1 - (1000*(((Yf * P * Dh) / (2 * (R + (0.6 * Yf * P)))) / Tn));
           return res;

        }




        public static double sredniiDopustIznosStenki(double Vcp, double Td, double Tn)
        {

            return ((Vcp / Tn) * Td);

        }





        // фунция расчета остаточного ресурса трубопровода
        public static double Ostatok(double Td, double Yf, double P, double Dh, double caseR,
                                     double R2, double R1, double m2, double Ym, double Yn,
                                     double Ys, double Tn, double Vcp,  double Veroyatnost,
                                     double r, double delta, double L)
        {


            double Ostatok = Td * ((dopustIsnosStenki( Yf, P, Dh, caseR, R2, R1, m2, Ym, Yn, Ys, Tn) - sredniiDopustIznosStenki(Vcp, Td, Tn)) / (dopustIsnosStenki(Yf, P, Dh, caseR, R2, R1, m2, Ym, Yn, Ys, Tn) / ((Kvantil_Uq( r, delta, L) / (Kvantil_Uy(Veroyatnost, r, delta, L)) - 1)) + sredniiDopustIznosStenki(Vcp, Td, Tn)));

            return Ostatok;
        }

    }
}
