﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yesbd
{
    public class SpellAmountBangla
    {
        public static string MoneyConvFn(string MVal)
        {
            string TxtMon = MVal;
            string iout = "";

            if (TxtMon.Trim().Length > 21)
            {
                iout = "Maximum 21 digits only Allowed";
            }
            else
            {
                iout = NToW(TxtMon.Trim());
            }

            return iout;
        }

        private static string One(Int64 x)
        {
            switch (x)
            {
                case 1:
                    return "এক";
                case 2:
                    return "দুই";
                case 3:
                    return "তিন";
                case 4:
                    return "চার";
                case 5:
                    return "পাঁচ";
                case 6:
                    return "ছয়";
                case 7:
                    return "সাত";
                case 8:
                    return "আট";
                case 9:
                    return "নয়";
                default:
                    return "";

            }
        }

        private static string two(Int64 x, Int64 y)
        {
            switch (x)
            {
                case 1:
                    switch (y)
                    {
                        case 0:
                            return "দশ";
                        case 1:
                            return "এগার";
                        case 2:
                            return "বার";
                        case 3:
                            return "তের";
                        case 4:
                            return "চৌদ্দ";
                        case 5:
                            return "পনের";
                        case 6:
                            return "ষোল";
                        case 7:
                            return "সতের";
                        case 8:
                            return "আঠার";
                        case 9:
                            return "ঊনিশ";
                        default:
                            return "";
                    }
                case 2:
                    return "বিশ ";
                case 3:
                    return "তিরিশ ";
                case 4:
                    return "চল্লিশ ";
                case 5:
                    return "পঞ্চাশ ";
                case 6:
                    return "ষাট ";
                case 7:
                    return "সত্তর ";
                case 8:
                    return "আশি ";
                case 9:
                    return "নব্বই ";
                default:
                    return "";
            }
        }

        private static string three(Int64 x)
        {
            if (x != 0)  //to avoid empty hundred for 1000
            {
                string xx = One(x) + " শত ";
                return xx;
            }
            else
                return "";
        }

        private static string frfv(Int64 x, Int64 y)
        {
            if (x == 0 && y == 0)
            {
                return "";
            }
            else
            {
                if (x != 0)
                {
                    if (x != 1)
                    {
                        return two(x, y) + One(y) + " হাজার ";
                    }
                    else
                    {
                        return two(x, y) + " হাজার ";
                    }
                }
                else
                {
                    return One(y) + " হাজার ";
                }
            }
        }

        private static string sxsn(Int64 x, Int64 y)
        {
            if (x == 0 && y == 0)
            {
                return "";
            }
            else
            {
                if (x != 0)
                {
                    if (x != 1)
                    {
                        return two(x, y) + One(y) + " লক্ষ ";
                    }
                    else
                    {
                        return two(x, y) + " লক্ষ ";
                    }
                }
                else
                {
                    return One(y) + " লক্ষ ";
                }
            }
        }

        private static string etnn(Int64 x, Int64 y)
        {
            if (x == 0 && y == 0)
            {
                return "";
            }
            else
            {
                if (x != 0)
                {
                    if (x != 1)
                    {
                        return two(x, y) + One(y) + " কোটি ";
                    }
                    else
                    {
                        return two(x, y) + " কোটি ";
                    }
                }
                else
                {
                    return One(y) + " কোটি ";
                }
            }
        }

        private static string NToWConv(String aaa)
        {
            Int64[] no = new Int64[10];
            int k;
            string a = "";
            k = aaa.Length;
            for (int j = 0; j < 7; j++)
            {
                if (k > 0)
                {
                    no[j] = Convert.ToInt64(aaa.Substring(k - 1, 1));
                }
                else
                {
                    no[j] = 0;
                }
                k = k - 1;
            }

            a = a + sxsn(no[6], no[5]);
            a = a + frfv(no[4], no[3]);
            a = a + three(no[2]);
            //if (no[1] != 0 || no[0] != 0)
            //{
            //    a = a + " and ";
            //}
            if (a.Trim().Length > 0)
            {
                if (no[1] != 0 || no[0] != 0)
                {
                    a = a + " এবং ";
                }
            }

            a = a + two(no[1], no[0]);
            if (no[1] != 1)
            {
                a = a + One(no[0]);
            }
            return a;
        }

        public static string NToW(String ParaNum)
        {
            //*****************************************
            //Int64 can have maximum value as 9,223,372,036,854,775,807.
            if (ParaNum.Length > 21)
            {
                return "Maximum 21 digits only Allowed";
            }
            Decimal a1 = Convert.ToDecimal(ParaNum);
            Int64 a2 = (Int64)Decimal.Floor(a1);
            Decimal a3 = a1 - a2;
            if (a2.ToString().Length > 21)
            {
                return "Maximum 21 digits only Allowed";
            }

            Int64 Part1, Part2, Part3, TempV1, TempV2;
            TempV1 = TempV2 = Part1 = Part2 = Part3 = 0;
            Int64 Fr = (Int64)(a3 * 100);
            TempV1 = a2;

            TempV2 = (Int64)Decimal.Floor(TempV1 / 10000000);
            Part1 = TempV1 - TempV2 * 10000000;
            TempV1 = TempV2;

            if (TempV1 >= 10000000)
            {
                TempV2 = (Int64)Decimal.Floor(TempV1 / 10000000);
                Part2 = TempV1 - TempV2 * 10000000;
                TempV1 = TempV2;
            }
            else
            {
                Part2 = TempV1;
                TempV1 = 0;
            }

            if (TempV1 >= 10000000)
            {
                TempV2 = (Int64)Decimal.Floor(TempV1 / 10000000);
                Part3 = TempV1 - TempV2 * 10000000;
                TempV1 = TempV2;
            }
            else
            {
                Part3 = TempV1;
                TempV1 = 0;
            }
            if (TempV1 >= 10000000)
            {
                return "Taka Conversion Error: Number exceeds the Length 21 digits";
            }

            string NName = "";
            int ln = NName.Trim().Length;

            if (Part3 > 0)
            {
                NName = NName.Trim() + NToWConv(Part3.ToString()) + " কোটি কোটি";
            }
            if (Part2 > 0)
            {
                if (Part2 == 1)
                {
                    NName = NName.Trim() + "" + NToWConv(Part2.ToString()) + " কোটি";
                }
                else
                {
                    NName = NName.Trim() + "" + NToWConv(Part2.ToString()) + " কোটি";
                }
            }
            if (Part1 > 0)
            {
                NName = NName.Trim() + "" + NToWConv(Part1.ToString());
            }
            if (NName.Trim().Length > 0)
            {
                //NName = "টাকা " + NName;
                NName = "" + NName;
            }
            if (Fr > 0)
            {
                if (NName.Trim().Length > 0)
                {
                    NName = NName.Trim() + " এবং " + NToWConv(Fr.ToString()) + " পয়সা";
                }
                else
                {
                    NName = NToWConv(Fr.ToString()) + " পয়সা";
                }
            }
            if (NName.Trim().Length > 0)
            {
                //NName = NName + " মাত্র";
                NName = NName + "";
            }
            return NName;
        }

        public static String comma(decimal amount)
        {
            string result = "";
            string amt = "";
            string amt_paisa = "";
            string minusCheck = "";

            string amnt = amount.ToString();
            minusCheck = amnt.Substring(0,1);
            if (minusCheck == "-")
            {
                decimal Famount = (amount*-1);

                amt = Famount.ToString();
                int aaa = Famount.ToString().IndexOf(".", 0);
                amt_paisa = Famount.ToString().Substring(aaa + 1);

                if (amt == amt_paisa)
                {
                    amt_paisa = "";
                }
                else
                {
                    amt = Famount.ToString().Substring(0, Famount.ToString().IndexOf(".", 0));
                    amt = (amt.Replace(",", "")).ToString();
                }
                switch (amt.Length)
                {
                    case 15:
                        if (amt_paisa == "")
                        {
                            result ="-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 2) + "," + amt.Substring(12, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 2) + "," + amt.Substring(12, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 14:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," + amt.Substring(7, 2) + "," +
                                     amt.Substring(9, 2) + "," + amt.Substring(11, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," + amt.Substring(7, 2) + "," +
                                     amt.Substring(9, 2) + "," + amt.Substring(11, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 13:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 12:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," +
                                     amt.Substring(7, 2) + "," + amt.Substring(9, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," +
                                     amt.Substring(7, 2) + "," + amt.Substring(9, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 11:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," +
                                     amt.Substring(6, 2) + "," + amt.Substring(8, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," +
                                     amt.Substring(6, 2) + "," + amt.Substring(8, 3) + "." +
                                     amt_paisa;
                        }
                        break;

                    case 10:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," +
                                     amt.Substring(5, 2) + "," + amt.Substring(7, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," +
                                     amt.Substring(5, 2) + "," + amt.Substring(7, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 9:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 2) + "," + amt.Substring(6, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 2) + "," + amt.Substring(6, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 8:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 2) + "," + amt.Substring(5, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 2) + "," + amt.Substring(5, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 7:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 3) + "." + amt_paisa;
                        }
                        break;
                    case 6:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 3) + "." + amt_paisa;
                        }
                        break;
                    case 5:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 2) + "," + amt.Substring(2, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 4:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 3);
                        }
                        else
                        {
                            result = "-" + amt.Substring(0, 1) + "," + amt.Substring(1, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    default:
                        if (amt_paisa == "")
                        {
                            result = "-" + amt;
                        }
                        else
                        {
                            result = "-" + amt + "." + amt_paisa;
                        }
                        break;
                }
            }
            else
            {
                amt = amount.ToString();
                int aaa = amount.ToString().IndexOf(".", 0);
                amt_paisa = amount.ToString().Substring(aaa + 1);

                if (amt == amt_paisa)
                {
                    amt_paisa = "";
                }
                else
                {
                    amt = amount.ToString().Substring(0, amount.ToString().IndexOf(".", 0));
                    amt = (amt.Replace(",", "")).ToString();
                }
                switch (amt.Length)
                {
                    case 15:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 2) + "," + amt.Substring(12, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 2) + "," + amt.Substring(12, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 14:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," + amt.Substring(7, 2) + "," +
                                     amt.Substring(9, 2) + "," + amt.Substring(11, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," + amt.Substring(7, 2) + "," +
                                     amt.Substring(9, 2) + "," + amt.Substring(11, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 13:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," + amt.Substring(6, 2) + "," +
                                     amt.Substring(8, 2) + "," + amt.Substring(10, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 12:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," +
                                     amt.Substring(7, 2) + "," + amt.Substring(9, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," + amt.Substring(5, 2) + "," +
                                     amt.Substring(7, 2) + "," + amt.Substring(9, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 11:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," +
                                     amt.Substring(6, 2) + "," + amt.Substring(8, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," + amt.Substring(4, 2) + "," +
                                     amt.Substring(6, 2) + "," + amt.Substring(8, 3) + "." +
                                     amt_paisa;
                        }
                        break;

                    case 10:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," +
                                     amt.Substring(5, 2) + "," + amt.Substring(7, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," + amt.Substring(3, 2) + "," +
                                     amt.Substring(5, 2) + "," + amt.Substring(7, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 9:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 2) + "," + amt.Substring(6, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 2) + "," + amt.Substring(6, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 8:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 2) + "," + amt.Substring(5, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 2) + "," + amt.Substring(5, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 7:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                     amt.Substring(4, 3) + "." + amt_paisa;
                        }
                        break;
                    case 6:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                     amt.Substring(3, 3) + "." + amt_paisa;
                        }
                        break;
                    case 5:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 2) + "," + amt.Substring(2, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    case 4:
                        if (amt_paisa == "")
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 3);
                        }
                        else
                        {
                            result = amt.Substring(0, 1) + "," + amt.Substring(1, 3) + "." +
                                     amt_paisa;
                        }
                        break;
                    default:
                        if (amt_paisa == "")
                        {
                            result = amt;
                        }
                        else
                        {
                            result = amt + "." + amt_paisa;
                        }
                        break;
                }
                //return result;
            }
            return result;
        } 

    }
}