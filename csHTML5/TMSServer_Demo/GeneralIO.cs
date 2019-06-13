//Silverlight 참조 추가 : C:\Program Files\Microsoft SDKs\Silverlight\v4.0\Libraries\Client\Microsoft.CSharp.dll
//CShartDotNet 이 Define되어있지 않으면 Silverlight 버젼
#define CShartDotNet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileIO
{
    public class GeneralIO
    {
        public static long GetRandomNumber(int nStart, int nEnd)
        {
            nEnd = nEnd + 1; // nEnd 에 1을 더한범위까지 출력됨
            Random random = new Random();
            return (long)random.Next(nStart, nEnd);
        }

        //nMaxCount 자리수 : ex:2:십단위, 3 -> 백단위 
        public static string RandomGenerate(int nMaxCount)
        {
            int nVal;
            string sRet = "";
            string sVal;
            try
            {
                Random random = new Random();

                for (int i = 0; i < nMaxCount; ++i)
                {
                    nVal = random.Next(0, 99999999);
                    sVal = string.Format("{0:00000}", nVal);
                    sVal = SuperString.StringParser.Right(sVal, 1);

                    sRet += sVal;
                }
                return sRet;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }


        //szSource == "http://www.naver.com/a" 4
        //szSource == "http://www.naver.com/a/" 4
        //szSource == "http://www.naver.com/a/a.htm" 5

        //szSource == "c:\\www.naver.com\\a" 3
        //szSource == "c:\\www.naver.com\\a\\" 3
        //szSource == "c:\\www.naver.com\\a\\a.txt" 4

        //맨 끝에는 / or \\가 붙는다.

        //\\ or /를 찾을 수 없을 경우 szSource을 리턴.

        ////////////주의 파일에 .이 없거나 폴더에 .이 있으면 안됨..

        public static string GetJustPath( string sPath)
        {
            //return "Error" if Error
            int nCnt;
            string sSource, sBase, sLast, sProtocal = "";

            try
            {
                sSource = sPath;

                sBase = (sSource.IndexOf('\\') == -1) ? "/" : "\\" ;
                
                if (sSource.IndexOf('\\') != -1)
                    sBase = "\\";
                else if (SuperString.StringParser.IsDomain(sSource))
                {
                    sProtocal = SuperString.StringParser.GetNthStr(sSource, 1, "//");
                    if (sProtocal.IndexOf(":") != -1)
                    {
                        sSource = sSource.Replace(sProtocal + "//", "");
                        sProtocal += "//";
                    }
                    else
                    {
                        sSource = sProtocal;
                        sProtocal = "";
                    }
                    sBase = "/";
                }
                else
                    sBase = "/";

                nCnt = SuperString.StringParser.GetStrCount(sSource, sBase);
                sLast = SuperString.StringParser.GetNthStr(sSource, nCnt, sBase);
                sLast = sLast.ToLower();

                if (sBase == "\\")
                {
                    //파일일 경우..
                    //.이 없으면 폴더라고 생각, 하지만 . 이 있는 폴더도 있다.. 
                    if (sLast.IndexOf(".") != -1 || sLast.IndexOf("*") != -1 || sLast.IndexOf("?") != -1)
                        sSource = SuperString.StringParser.Replace(sSource, nCnt, sBase, "");
                }
                else if (sBase == "/")
                {
                    if (sLast.IndexOf(".") != -1 || sLast.IndexOf("asp") != -1 || sLast.IndexOf("jsp") != -1 || sLast.IndexOf("php") != -1)
                    {
                        //파일로 볼지 폴더로 볼지
                        char chLastSlash = sSource[sSource.Length - 1];

                        if (chLastSlash != '/')
                        {
                            if (nCnt > 1)
                                sSource = SuperString.StringParser.Replace(sSource, nCnt, sBase, "");
                            else
                            {
                                sSource = sProtocal + sSource;
                                sSource = sSource.TrimEnd('/');
                                sSource += "/";
                                return sSource;
                            }
                        }
                    }
                }

                if (sSource == "") return sSource;

                sLast = sSource[(sSource.Length - 1)].ToString();

                if (sLast != sBase)
                    sSource += sBase;

                //그래도 파일 일 경우는 파일에 확장자가 없는경우.. 이전 Path 리턴.
                string sTSource = sSource;
                sTSource = sTSource.TrimEnd('\\');

                return sSource;
            }
            catch (Exception error)
            {
                string sErr = error.ToString();
                return "";
            }
        }

        public static string GetJustPath(ref string sPath)
        {
            //return "Error" if Error
            int nCnt;
            string sSource, sBase, sLast, sProtocal = "";

            try
            {
                sSource = sPath;

                sBase = (sSource.IndexOf('\\') == -1) ? "/" : "\\" ;
                
                if (sSource.IndexOf('\\') != -1)
                    sBase = "\\";
                else if (SuperString.StringParser.IsDomain(sSource))
                {
                    sProtocal = SuperString.StringParser.GetNthStr( sSource, 1, "//" );
                    if (sProtocal.IndexOf(":") != -1)
                    {
                        sSource = sSource.Replace(sProtocal + "//", "");
                        sProtocal += "//";
                    }
                    else
                    {
                        sSource = sProtocal;
                        sProtocal = "";
                    }
                    sBase  = "/";
                }
                else
                    sBase  = "/";

                nCnt  = SuperString.StringParser.GetStrCount( sSource, sBase );
                sLast = SuperString.StringParser.GetNthStr( sSource, nCnt, sBase );
                sLast = sLast.ToLower();

                if( sBase == "\\" )
                {
                    //파일일 경우..
                    //.이 없으면 폴더라고 생각, 하지만 . 이 있는 폴더도 있다.. 
                    if( sLast.IndexOf( "." ) != -1 || sLast.IndexOf( "*" ) != -1 || sLast.IndexOf( "?" ) != -1 )
                        sSource = SuperString.StringParser.Replace( sSource, nCnt, sBase, "" );
                }
                else if( sBase == "/" )
                {
                    if( sLast.IndexOf( "." ) != -1 || sLast.IndexOf( "asp" ) != -1 || sLast.IndexOf( "jsp" ) != -1 || sLast.IndexOf( "php" ) != -1 )
                    {
                        //파일로 볼지 폴더로 볼지
                        char chLastSlash = sSource[sSource.Length - 1];

                        if (chLastSlash != '/')
                        {
                            if (nCnt > 1)
                                sSource = SuperString.StringParser.Replace(sSource, nCnt, sBase, "");
                            else
                            {
                                sSource = sProtocal + sSource;
                                sSource = sSource.TrimEnd('/');
                                sSource += "/";
                                return sSource;
                            }
                        }
                    }
                }

                if (sSource == "") return sSource;

                sLast = sSource[(sSource.Length - 1)].ToString();

                if (sLast != sBase)
                    sSource += sBase;

                //그래도 파일 일 경우는 파일에 확장자가 없는경우.. 이전 Path 리턴.
                string sTSource = sSource;
                sTSource = sTSource.TrimEnd('\\');
                return sSource;
            }
            catch (Exception error)
            {
                string sErr = error.ToString();
                return "";
            }
        }

 

        //http://www.naver.com/aa/bb/ 5
        //http://www.naver.com/aa/bb/a.htm 6
        //https:....

        //c:\\temp\\aa
        //c:\\temp\\aa\\
        //c:\\temp\\aa\\a.txt

        //Last inserted the "/"
        //return "" if Error
        //->To CGeneralIO
        public static string GetBeforePath(string sPath, int nBeforeCnt)
        {
            int nSiteFrom = 0, nSiteTo = 0, nSpeciseSu = 0, nCnt = 0;
            string sSeparator, sPath1;
            try
            {
                if (nBeforeCnt <= 0) return sPath;

                sPath1 = GeneralIO.GetJustPath(ref sPath);

                sSeparator = (sPath1.IndexOf("\\") != -1) ? "\\" : "/";

                nCnt = SuperString.StringParser.GetStrCount(sPath1, sSeparator);
                string sEntry = SuperString.StringParser.GetNthStr(sPath1, nCnt, sSeparator);

                sEntry = SuperString.StringParser.GetStrFromStr(sPath1, nCnt - (nBeforeCnt - 1), sSeparator, out nSiteFrom, out nSiteTo, out nSpeciseSu);

                if (sEntry == "")
                    return "";

                return sPath = SuperString.StringParser.Left(sPath1, nSiteFrom);
            }
            catch (Exception error)
            {
                string sErr = error.ToString();
                return "";
            }
        }

        public static string GetBeforePath(ref string sPath, int nBeforeCnt)
        {
            int nSiteFrom = 0, nSiteTo = 0, nSpeciseSu = 0, nCnt = 0;
            string sSeparator, sPath1;
            try
            {
                if( nBeforeCnt <= 0 ) return sPath;

                sPath1 = GeneralIO.GetJustPath(ref sPath);

                sSeparator = (sPath1.IndexOf("\\") != -1) ? "\\" : "/";

                nCnt = SuperString.StringParser.GetStrCount(sPath1, sSeparator);
                string sEntry = SuperString.StringParser.GetNthStr(sPath1, nCnt, sSeparator);

                sEntry = SuperString.StringParser.GetStrFromStr(sPath1, nCnt - (nBeforeCnt - 1), sSeparator, out nSiteFrom, out nSiteTo, out nSpeciseSu);
        
                if( sEntry == "" )
                    return "";

                return sPath =  SuperString.StringParser.Left( sPath1, nSiteFrom);
            }
            catch (Exception error)
            {
                string sErr = error.ToString();
                return "";
            }
        }        
       



    } // Class GeneralIO
}
