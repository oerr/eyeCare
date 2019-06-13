using System;
using System.Net;

namespace System
{
    public class EConvert 
    {
        public static string ToString(int nVal)
        {
            try
            {
                string sVal = string.Format("{0:#,###}", nVal);
                if (sVal == "") sVal = "0";
                return sVal;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public static string ToString(short nVal)
        {
            try
            {
                string sVal = string.Format("{0:#,###}", nVal);
                if (sVal == "") sVal = "0";
                return sVal;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public static string ToString(long nVal)
        {
            try
            {
                string sVal = string.Format("{0:#,###}", nVal);
                if (sVal == "") sVal = "0";
                return sVal;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public static string ToString(double dwVal)
        {
            try
            {
                string sVal = string.Format("{0:0,0.000}", dwVal);

                if (sVal.IndexOf(".") != -1)
                {
                    while (true)
                    {
                        if (SuperString.StringParser.Right(sVal, 1) == "0" || SuperString.StringParser.Right(sVal, 1) == ".")
                        {
                            if (SuperString.StringParser.Right(sVal, 1) == ".")
                            {
                                sVal = SuperString.StringParser.Left(sVal, sVal.Length - 1);
                                break;
                            }
                            sVal = SuperString.StringParser.Left(sVal, sVal.Length - 1);
                            continue;
                        }
                        break;
                    }
                }

                //00.3 -> 0.3                
                //02.45 -> 2.45
                //00 -> 0

                int i = 0;
                for (i = 0; i < sVal.Length; ++i)
                {
                    if (sVal[i] != '0') break;
                }

                if (i >= sVal.Length)
                    sVal = SuperString.StringParser.Right(sVal, sVal.Length - (i - 1));
                else
                {
                    if (sVal[i] != '.')
                        sVal = SuperString.StringParser.Right(sVal, sVal.Length - (i));
                    else
                        sVal = SuperString.StringParser.Right(sVal, sVal.Length - (i - 1));
                }
                if (sVal == "") sVal = "0";

                return sVal;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public static double ToDouble(string sVal)
        {
            try
            {
                sVal = sVal.Trim();
                sVal = sVal.Replace(",","");
                if(sVal == "") sVal = "0";
                return System.Convert.ToDouble(sVal);                
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static long ToInt64(string sVal)
        {
            try
            {
                sVal = sVal.Trim();
                sVal = sVal.Replace(",", "");
                if (sVal == "") sVal = "0";
                return System.Convert.ToInt64(sVal);
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static int ToInt32(string sVal)
        {
            try
            {
                sVal = sVal.Trim();
                sVal = sVal.Replace(",", "");
                if (sVal == "") sVal = "0";
                return System.Convert.ToInt32(sVal);
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static short ToInt16(string sVal)
        {
            try
            {
                sVal = sVal.Trim();
                sVal = sVal.Replace(",", "");
                if (sVal == "") sVal = "0";
                return System.Convert.ToInt16(sVal);
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
    }
}
