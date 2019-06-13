//Silverlight 참조 추가 : C:\Program Files\Microsoft SDKs\Silverlight\v4.0\Libraries\Client\Microsoft.CSharp.dll
//CShartDotNet 이 Define되어있지 않으면 Silverlight 버젼
//#define CShartDotNet

using System.Runtime.InteropServices;
using System.Reflection;

using System;
using System.Net;
using System.Text;//StringBuilder
using System.Threading;

#if CShartDotNet
    using WPLOGLib;
#endif

namespace SuperString
{
    //public class StringParserBlocking
    //{
    //    public bool bBlocking = true;
    //}

    public class StringParser
    {
        string[] m_aParse;

#if CShartDotNet
        static private WPLOGLib.SinkLog g_Evt = null;
#else
        /* ActiveX
        static dynamic g_oDynamicLog = null;
        static object[] g_oWndLog = null;
        */
#endif

        public enum EventLogType
        {
            eventlog_error_type = 1,
            eventlog_warning_type = 2,
            eventlog_information_type = 4,
            eventlog_user_information_type = 32,
            eventlog_timechk_type = 64
        };

        //sFind의 i+1부터 다음 번째 index(cSysBase구분자)이동. cSysBase가 있는 Index까지. 끝일 경우 -1을 리턴.
        public static int GoToNextBase(int i, string sFind, char cSysBase)
        {
            return sFind.IndexOf(cSysBase, i + 1);
        }

        /// <summary>
        /// VB에서 LEFT 기능
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="len">자르고자 하는 수</param>
        /// <returns></returns>
        public static string Left(string str, int len)
        {
            string convertStr;
            if (str.Length < len)
                len = str.Length;

            convertStr = str.Substring(0, len);

            return convertStr;
        }

        /// <summary>
        /// VB에서 RIGHT 기능
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="len">자르고자 하는 수</param>
        /// <returns></returns>
        public static string Right(string str, int len)
        {
            string convertStr;
            if (str.Length < len)
                len = str.Length;

            convertStr = str.Substring(str.Length - len, len);

            return convertStr;
        }

        /// <summary>
        /// VB에서 MID 기능
        /// </summary>
        /// <param name="str">문자열</param>
        /// <param name="startInt">시작 Index</param>
        /// <param name="endInt">종료 Index</param>
        /// <returns></returns>
        public static string Mid(string str, int startInt, int endInt)
        {
            string convertStr;
            if (startInt < str.Length || endInt < str.Length)
            {
                convertStr = str.Substring(startInt, endInt);
                return convertStr;
            }
            else
                return str;
        }
        public static string Mid(string str, int startInt)
        {
            int endInt = str.Length - startInt;
            string convertStr;
            if (startInt < str.Length || endInt < str.Length)
            {
                convertStr = str.Substring(startInt, endInt);
                return convertStr;
            }
            else
                return str;
        }
        public void RemoveAllParse()
        {
            m_aParse = new string[]{};
        }
        public int Parse(string sSrc, string sBase)
        {
            m_aParse = sSrc.Split(new string[] { sBase }, StringSplitOptions.None);
            return m_aParse[m_aParse.Length - 1] == "" ? m_aParse.Length - 1 : m_aParse.Length;
        }
        public int GetParseCount()
        {
            return m_aParse[m_aParse.Length - 1] == "" ? m_aParse.Length - 1 : m_aParse.Length;
        }
        public string GetParseAt(int nIdx)
        {
            if (nIdx >= m_aParse.Length) return "";
            return m_aParse[nIdx];
        }
        public void SetParseAt(int nIdx, string sData)
        {
            if (nIdx >= m_aParse.Length) return;
            m_aParse[nIdx] = sData;
        }

        // strBase 토큰을 사용하여 strSource를 분리했을 때 나오는 문자열의 개수
        // ex) GetStrCount("abc|&234|&hong|&myjob", "|&")
        //     => 4
        public static int GetStrCount(string sSource, string sBase)
        {
            string[] sARet = sSource.Split(new string[] { sBase }, StringSplitOptions.None);
            return sARet[sARet.Length - 1] == "" ? sARet.Length - 1 : sARet.Length;
        }

        // strSource에서 nFrom번째 스트링을 얻는다. 
        // strBase: 구분 토큰
        // nFrom: 시작 인덱스 1
        // ex)  GetNthStr("abc|&234|&hong|&myjob", 2, "|&")
        //                  => "234"
        public static string GetNthStr(string sSource, int nFrom, string sBase)
        {
            try
            {
                string[] sARet = sSource.Split(new string[] { sBase }, StringSplitOptions.None);
                return sARet[nFrom - 1];
            }
            catch (System.Exception ex)
            {
                return "";	
            }
        }

        //sData       : aa<E>cc<E>dd<E>ee
        //nIndex      : 2
        //sBase       : <E>
        //sInsertData : bb
        //return      : aa<E>bb<E>cc<E>dd<E>ee
        public static string InsertAt(string sData, int nIndex, string sBase, string sInsertData)
        {
            string sValue;
            string sStateMsg;
            int nSiteFrom, nSiteTo, nCnt;
            try
            {
                SuperString.StringParser.GetStrFromStr(sData, nIndex, sBase, out nSiteFrom , out nSiteTo, out nCnt);
                sValue = string.Format("{0}{1}", sInsertData, sBase);
                sData = sData.Insert( nSiteFrom, sValue);
                return sData;
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::InsertAt Catch Error:{0}", sErr);
                return "";
            }
        }
        
        //Return  : nFrom이 잘못됬을경우 ""을 리턴.
        //Param   :
        //Notes   :
        //CString sBase = _T("|&");
        //int nSiteFrom(0), nSiteTo(0), nCnt(0);
        //CString sValue = CSuperString::GetStrFromStr("abc|&def|&ghi|&jkl",4,sBase,&nSiteFrom,&nSiteTo,&nCnt);
        //여기서 jkl를 리턴. sFBase:"",nSiteFrom:15, nSiteTo:17, nCnt:사용안함.  
        //만일 nSiteFrom이 5일경우 "" 리턴.

        //CString strValue = CSuperString::GetStrFromStr("abc|&def|&ghi|&jkl",-1,sBase,sFBase.GetBuffer(sBase.GetLength()),&nSiteFrom,&nSiteTo,&nCnt);
        //여기서 "" 리턴. sFBase:"", nSiteFrom:사용안함, nSiteTo:사용안함, nCnt:4를 리턴. -> -1일 경우 Count를 얻는다.

        //CString strValue = CSuperString::GetStrFromStr("abc|&def|&ghi|&",-1,sBase,sFBase.GetBuffer(sBase.GetLength()),&nSiteFrom,&nSiteTo,&nCnt);
        //여기서 "" 리턴. nSiteFrom:사용안함, nSiteTo:사용안함, nCnt:3을 리턴.
        public static string GetStrFromStr(string sSource, int nFrom, string sBase, out int nSiteFrom, out int nSiteTo, out int nCnt)
        {
            string strRet = "";
            int nFind = 0;
            int nSite = 0;
            int nSiteBack = 0;
            string sStateMsg;

            nSiteFrom = 0;
            nSiteTo   = 0;
            nCnt      = 0;

            try
            {
                if (string.IsNullOrEmpty(sSource))
                {
                    nCnt = 0;
                    return "";
                }

                if (sBase.Length > sSource.Length) 
                {
                    nCnt = 1;
                    return sSource;
                }

                int nSourceSize = sSource.Length;
                int nBaseSize   = sBase.Length;

                if (sSource.IndexOf(sBase, nSourceSize - nBaseSize) == -1)
                    sSource += sBase;

                while( nSite < nSourceSize )
                {
                    nSite = sSource.IndexOf(sBase, nSite);
                    if( nSite == -1 ) break;

                    ++nFind;
                    if( nFind == nFrom )
                    {
                        //for( int i = nSiteBack; i < nSite; ++i )
                        //    strRet += sSource[i];  => 아래가 속도가 더 빠름.

                        strRet += sSource.Substring(nSiteBack, nSite - nSiteBack);
                        break;
                    }
                    nSite    += nBaseSize;
                    nSiteBack = nSite;
                }

                nSiteFrom  = nSiteBack;
                nSiteTo    = nSite-1;
                nCnt       = nFind;

                return strRet;
            }
            catch(Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::GetStrFromStr Catch Error:{0}", sErr);
                return "";
            }
        }

        //return string index of found(0 index based). return -1 if there is no any string
        //nStart: 0 based start index.
        public static int Find(string sSource, string sFind, int nStart)
        {
            string sStateMsg;
            try
            {
                if (sSource == "") return -1;
                return sSource.IndexOf(sFind, nStart);
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::Find Catch Error:{0}", sErr);
                return -1;
            }
        }

        //return string index of found(0 index based). return -1 if there is no any string
        //nStart: 0 based start index.
        public static int FindNoCase(string sSource, string sFind, int nStart=0)
        {
            string sStateMsg;
            try
            {
                if( sSource == "" ) return -1;
        
                sSource = sSource.ToLower();
                sFind = sFind.ToLower();
                return sSource.IndexOf( sFind, nStart );
            }
            catch(Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::FindNoCase Catch Error:{0}", sErr);
                return -1;
            }
        }
        

        //Return   : 찾은 문자열 Index(0기반), -1일 경우 못찾거나 에러.
        //Param    : 
        //szSource : 소스 문자열
        //szFind   : 찾을 문자열(cSysBase를 구분자로)
        //cSysBase : szFind에서 구분자로 사용할 구분자
        //szFBase  : 찾았을때 찾을 문자열중(구분자로 구분) 어떤 문자열인지 outparam
        //nStart   : 0기반 index로 From
        //Notes    :
        //szSource : "안녕AND뭘봐OR그래BETA얌마"
        //szFind   : "AND^OR^BETA"
        //cSysBase : '^'
        //szSource를 nStart부터(0기반) 부터 찾아서 AND가 있거나, OR가 있거나 BETA가 있으면 
        //그 찾은 0기반 Index를 리턴, 이때 찾은 구분자를 (AND 혹은 OR 혹은 BETA)를 szFBase에 outparam으로 전달.(물론 szFBase는 NULL이 아니어야 함)
        //History :
        //000 - 01/26/2007 - 문 승혁 - Creation
        public static int FindEx(string sSource, string sFind, char cSysBase, out string sFBase, int nStart)
        {
            string sStateMsg;
            bool bFinded = false;
            int nSourceLen = 0;
            int i = 0;
            int ii = 0;
            int j = 0;
            int nFindLen = 0;
            sFBase = "";

            try
            {
                if (sFind[sFind.Length - 1] == cSysBase)
                    sFind = Left(sFind, sFind.Length - 1);

                nSourceLen = sSource.Length;
                nFindLen = sFind.Length;

                if (nSourceLen <= nStart) return -1;

                for (i = nStart, ii = 0; i < nSourceLen; ++i)
                {
                    for (j = 0; j < nFindLen; ++j)
                    {
                        if (i + ii >= nSourceLen)
                        {
                            j = sFind.Length;
                            break;
                        }

                        if (sSource[i + ii] != sFind[j])
                        {
                            if (j < nFindLen && sFind[j] != cSysBase)
                            {
                                ii = 0;

                                //sFind의 j+1부터 다음 번째 index(cSysBase구분자)이동. cSysBase가 있는 Index까지. 끝일 경우 -1을 리턴.
                                j = GoToNextBase(j, sFind, cSysBase);

                                if (j == -1) break;
                                continue;
                            }
                            else
                            {
                                ii = 0;
                                bFinded = true;
                                break;
                            }
                        }
                        ++ii;
                    }

                    if (bFinded || j != -1)
                    {
                        int nFrom = 0;
                        int nTo = j - 1;
                        while (j > 0)
                        {
                            if (sFind[--j] == cSysBase)
                            {
                                nFrom = j + 1;
                                break;
                            }
                        }
                        nTo = nTo - nFrom + 1;
                        sFBase = Mid(sFind, nFrom, nTo);
                        return i;
                    }
                }
                return -1;
            }
            catch(Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::FindEx Catch Error:{0}", sErr);
                return -1;
            }
        }
    
    
    
        //Return  : 1기반 Index
        //Param   :
        //Remark  : int nIndex = GetIndexofSearch(_T("abc,def,ghi"), _T("def"), _T(","));
        //          nIndex == 2 없을 경우 -1
        //History : 
        //000 - 04/25/2005 - 문승혁 - Creation
        public static int GetIndexofSearch(string sSource, string sObject, string sBase)
        {
            string sStateMsg;
            string sTemp;
            int nCnt;

            try
            {
                //nCnt = GetStrCount(sSource, sBase);
                //for(int i = 1; i <= nCnt; ++i)
                //{
                //    sTemp = GetNthStr(sSource, i, sBase);
                //    if(sTemp == sObject)
                //        return i;
                //}

                int i = 0;
                string[] sARet = sSource.Split(new string[] { sBase }, StringSplitOptions.None);
                foreach (string sEntry in sARet)
                {
                    ++i;
                    if (sEntry == sObject) return i;
                }
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::GetIndexofSearch Catch Error:{0}", sErr);
            }
            return -1;
        }    
    
        public static string Replace(string sSource, int nFrom, string sBase, string sCharSet)
        {
	        string sStateMsg, strSource, strBase, strCharSet;
            try
            {
                strSource  = sSource;
                strBase    = sBase;
                strCharSet = sCharSet;

                if( strSource == "" ) return "";

	            int nSourceSize = strSource.Length;
	            int nBaseSize   = strBase.Length;
                bool bAddBase   = false;
	            if( strSource.IndexOf(strBase, nSourceSize - nBaseSize) == -1)
                {
                    bAddBase   = true;
		            strSource += strBase;
                }

                int nSiteFrom,nSiteTo,nSu;
                GetStrFromStr(strSource, nFrom, strBase, out nSiteFrom, out nSiteTo, out nSu);
                int nCount = nSiteTo - nSiteFrom + nBaseSize +1;
                strSource = strSource.Remove(nSiteFrom, nCount);

                if( strSource != "")
                {
                    if (strCharSet != "")
                        strSource = strSource.Insert(nSiteFrom, strCharSet + strBase);
                    if (bAddBase)
                        strSource = Left(strSource, strSource.Length - nBaseSize);
                }
                
                return strSource;
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::Replace Catch Error:{0}", sErr);
                return "Error";
            }
        }

        //\\ or /를 찾을 수 없을 경우 szSource을 리턴. CSuperString에서 사용하는 GetJustPath는 szSource가 반드시 파일이다.(LogTrace에서만 사용) 
        public static string GetJustPath(string szSource)
        {
            int nCnt;
            string sStateMsg, sSource, sBase, sLast;

            try
            {
                sSource = szSource;

                if( sSource == "" ) return "";

                if( sSource.IndexOf( "\\" ) != -1 )
                    sBase = "\\";
                else if( sSource.IndexOf( "/" ) != -1 )
                    sBase = "/";
                else
                    return szSource;

                nCnt  = GetStrCount( sSource, sBase );
                sLast = GetNthStr(sSource, nCnt, sBase);
        
                //.이 없으면 폴더라고 생각, 하지만 . 이 있는 폴더도 있다..
                if( sLast.IndexOf( "." ) != -1 || sLast.IndexOf( "*" ) != -1 || sLast.IndexOf( "?" ) != -1 )
                    sSource = Replace( sSource, nCnt, sBase, "" );
        
                if( sSource == "" ) return sSource;

                sLast = sSource[sSource.Length - 1].ToString();
        
                if( sLast != sBase )
                    sSource += sBase;
        
                return sSource;
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::GetJustPath Catch Error:{0}", sErr);
                return "Error";
            }
        }

        //!Return  :\r\n
        //!Param   :\r\n
        //!Remark  :\r\n
        //sData를 unsigned char* 로 바꾸어 리턴한다. 이때 pnSize에는 바꾼 크기
        //에러일 경우 NULL을 리턴하며 이 함수를 호출하고
        //unsigned char* pszData = StringToByte(...);
        //if( pszData != NULL ) { delete[]pszData; pszData = NULL; } 를 해 주어야한다.
        public static char[] StringToChar(string sData, out int nSize)
        {
            string sStateMsg;
            char[] pszData = null;
            try
            {
                nSize = 0;

                if( sData == "" ) return null;               
       
                pszData = new char[sData.Length+1];

                for (int i = 0; i < sData.Length; ++i)
                {
                    pszData[i] = sData[i];
                }
                nSize = sData.Length;
                return pszData;
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::StringToByte Catch Error:{0}", sErr);
                nSize = -1;
                return null;
            }
        }

        //public static byte[] StringToByte(string sData, out int nSize, bool bUTF8=true)
        //{
        //    byte[] bStrByte = null;

        //    if (bUTF8)
        //    {
        //        bStrByte = Encoding.UTF8.GetBytes(sData);   // string -> byte
        //        nSize = bStrByte.Length;
        //    }
        //    else
        //    {
        //        bStrByte = Encoding.Default.GetBytes(sData);   // string -> byte
        //        nSize = bStrByte.Length;
        //    }
        //    return bStrByte;
        //}

        //public static string ByteToString(byte[] pszData, int nSize, bool bUTF8 = true)
        //{
        //    string sRet = bUTF8 ? UTF8Encoding.UTF8.GetString(pszData, 0, nSize) : UTF8Encoding.Default.GetString(pszData, 0, nSize);
        //    return sRet;
        //}

        public static string CharToString(char [] pszData, int nSize)
        {
            //아래는 65 의 값을 "65"로 변환
            //string sRet = "";
            //for (int i = 0; i < nSize; ++i)
            //{
            //    sRet = sRet.Insert (sRet.Length, pszData[i].ToString() );
            //}
            //return sRet;

            //아래는 65 의 값을 "A"로 변환
            char ch;
            string sRet = "";
            for (int i = 0; i < nSize; ++i)
            {
                ch = pszData[i];
                sRet += ch;
            }
            return sRet;
        }

        //Return  : 
        //Param   :
        //Remark  : 0기반 nFromIndex부터 그 라인의 스트링을 얻어오는 함수 *pnNextIndex: 다음라인의 첫째 스트링의 Index
        //          호출하는 측에서 만일 *pnLastInde 가 sBuf보다 같거나 크면 끝으로 처리해야 함.

        //[선언]\r\n
        //사랑1=요지경\r\n
        //사랑2=저지경\r\n
        //[정의]\r\n
        //미움1=질투1\r\n
        //미움2=질투2\r\n

        //int nFromIndex(0), nNextIndex(0);
        //CString sLine;
        //sLine = GetLineData(sBuf,nFromIndex,&nNextIndex);
        //sLine == "[선언]" //nNextIndex==UNICODE가 Define되어있으면 6 아니면, 8
        //nFromIndex = nNextIndex;
        //sLine = GetLineData(sBuf,nFromIndex ,&nNextIndex);
        //sLine == "사랑1=요지경" //nNextIndex==UNICODE가 Define되어있으면 15 아니면, 22

        //History :
        //000 - 03/29/2005 - 문승혁 - Creation
        public static string GetLineData(string sBuf, int nFromIndex, out int nNextIndex)
        {
            int i = 0;
            string  sRetBuf = "";
            string sStateMsg;

            try
            {
                nNextIndex = -1;

                if( sBuf == "" ) return "";
        
                int nLength = sBuf.Length;
        
                for( i = nFromIndex; true ; ++i )
                {
                    if( i >= nLength ) 
                    {
                        nNextIndex = i;
                        return sRetBuf;
                    }
                    if( sBuf[i] != '\r' && sBuf[i] != '\n')
                        sRetBuf += sBuf[i];
                    else break;
                }
        
                while(true)
                {
                    if( i >= nLength )
                    {
                        nNextIndex = i;
                        return sRetBuf;
                    }
            
                    if( sBuf[i] != '\r' &&  sBuf[i] != '\n' )
                        break;
                    ++i;
                }
        
                nNextIndex = i;
                sRetBuf = sRetBuf.Trim();
                return sRetBuf;
            }
            catch (Exception Err)
            {
                nNextIndex = 0;
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::GetLineData Catch Error:{0}", sErr);
                return "";
            }
        }

        
        // strBase 토큰을 사용하여 strSource를 분리했을 때 나오는 문자열의 개수
        // ex) GetStrCount("abc|&234|&hong|&myjob", "|&")
        //     => 4
        public static int GetStrCountNoCase(string sSource, string sBase)
        {
            int nSiteFrom  = 0;
            int nSiteTo    = 0;
            int nCount = 0;
            
            GetStrFromStrNoCase(sSource, -1, sBase, out nSiteFrom, out nSiteTo, out nCount);
            return nCount;
        }

        // strSource에서 nFrom번째 스트링을 얻는다. 
        // strBase: 구분 토큰
        // nFrom: 시작 인덱스 1
        // ex)  GetNthStr("abc|&234|&hong|&myjob", 2, "|&")
        //                  => "234"
        public static string GetNthStrNoCase(string szSource, int nFrom, string sBase)
        {
            int nSiteFrom  = 0;
            int nSiteTo    = 0;
            int nCount = 0;

            return GetStrFromStrNoCase(szSource, nFrom, sBase, out nSiteFrom, out nSiteTo, out nCount);
        }

        //Return  : nFrom이 잘못됬을경우 ""을 리턴.
        //Param   :
        //Notes   :
        //CString sBase = _T("|&");
        //int nSiteFrom(0), nSiteTo(0), nCnt(0);
        //CString sValue = CSuperString::GetStrFromStrNoCase("ABC|&def|&ghi|&jkl",4,sBase,&nSiteFrom,&nSiteTo,&nCnt);
        //여기서 jkl를 리턴. sFBase:"",nSiteFrom:15, nSiteTo:17, nCnt:사용안함.  
        //만일 nSiteFrom이 5일경우 "" 리턴.

        //CString strValue = CSuperString::GetStrFromStrNoCase("ABC|&def|&ghi|&jkl",-1,sBase,sFBase.GetBuffer(sBase.GetLength()),&nSiteFrom,&nSiteTo,&nCnt);
        //여기서 "" 리턴. sFBase:"", nSiteFrom:사용안함, nSiteTo:사용안함, nCnt:4를 리턴. -> -1일 경우 Count를 얻는다.

        //CString strValue = CSuperString::GetStrFromStrNoCase("ABC|&def|&ghi|&",-1,sBase,sFBase.GetBuffer(sBase.GetLength()),&nSiteFrom,&nSiteTo,&nCnt);
        //여기서 "" 리턴. nSiteFrom:사용안함, nSiteTo:사용안함, nCnt:3을 리턴.
        public static string GetStrFromStrNoCase(string sSource, int nFrom, string sBase, out int nSiteFrom, out int nSiteTo, out int nCnt)
        {
            string strRet = "";
            string sStateMsg, strSource, strBase;
            int nFind = 0;
            int nSite = 0;
            int nSiteBack = 0; 
            try
            {
                nSiteFrom = 0;
                nSiteTo   = 0;
                nCnt      = 0;

                strSource = sSource;
                strBase   = sBase;
        
                if( strSource == "" )
                {
                    nCnt = 0;
                    return "";
                }
        
                if( strBase.Length > strSource.Length) 
                {
                    nCnt = 1;
                    return strSource;
                }
        
                int nSourceSize = strSource.Length;
                int nBaseSize   = strBase.Length;

                if( FindNoCase( strSource, strBase, nSourceSize - nBaseSize ) == -1 )
                    strSource += strBase;
        
                while( nSite < nSourceSize )
                {
           
                    nSite =   FindNoCase( strSource, strBase, nSite );
                    if( nSite != -1 )
                    {
                        ++nFind;
                        if( nFind==nFrom )
                        {
                            for( int i = nSiteBack; i < nSite; ++i )
                                strRet += strSource[i];
                            break;
                        }
                        nSite += nBaseSize;
                        nSiteBack = nSite;
                    }
                    else
                        break;
                }
        
                nSiteFrom  = nSiteBack;
                nSiteTo    = nSite-1;
                nCnt       = nFind;
        
                return strRet;
            }
            catch (Exception Err)
            {
                nSiteFrom = 0;
                nSiteTo   = 0;
                nCnt      = 0;
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::GetStrFromStrNoCase Catch Error:{0}", sErr);
                return "";
            }
        }



        // strBase 토큰을 사용하여 strSource를 분리했을 때 나오는 문자열의 개수
        // ex) GetStrCount("abc|&234|&hong|&myjob", "|&")
        //     => 4
        public static int GetStrCountEx(string sSource, string sBase, char cFBase)
        {
            int nSiteFrom = 0;
            int nSiteTo   = 0;
	        int nCount    = 0;
            string sOutBase = "";
	        GetStrFromStrEx( sSource, -1, sBase, cFBase, out sOutBase, out nSiteFrom, out nSiteTo, out nCount );
	        return nCount;
        }

        public static string GetNthStrEx(string sSource, int nFrom, string sBase, char cFBase, out string sOutBase)
        {
            sOutBase = "";
            int nSiteFrom = 0;
            int nSiteTo   = 0;
            int nCount    = 0;
            string  sRet = GetStrFromStrEx( sSource, nFrom, sBase, cFBase, out sOutBase, out nSiteFrom, out nSiteTo, out nCount);
	        return sRet;
        }

        //Return  : nFrom이 잘못됬을경우 ""을 리턴.
        //Param   :
        //Notes   :
        //CString sBase  = _T("AND|OR");
        //TCHAR   cFBase = _TCHAR("|");
        //CString sOutBase;
        //int nSiteFrom(0), nSiteTo(0), nCnt(0);
        //CString sValue = CSuperString::GetStrFromStrEx("12AND34OR56",2,sBase,cfBase,sOutBase.GetBuffer(sBase.GetLength()),&nSiteFrom,&nSiteTo,&nCnt);
        //sOutBase.ReleaseBuffer();
        //여기서 34를 리턴(2번째). sOutBase:"OR",nSiteFrom:5, nSiteTo:6, nCnt:사용안함.  

        //CString sValue = CSuperString::GetStrFromStrEx("12AND34OR56",-1,sBase,cfBase,sOutBase.GetBuffer(sBase.GetLength()),&nSiteFrom,&nSiteTo,&nCnt);
        //sOutBase.ReleaseBuffer();
        //여기서 "" 리턴. sOutBase:"", nSiteFrom:사용안함, nSiteTo:사용안함, nCnt:4를 리턴. -> -1일 경우 Count를 얻는다.

        //History :
        //000 - 01/25/2007 - 문 승혁 - Creation
        public static string GetStrFromStrEx(string sSource, int nFrom, string sBase, char cFBase, out string soutBase, out int nSiteFrom, out int nSiteTo, out int nCount)
        {
            string sEBase    = "";
            string strRet    = "";
            string sFBase    = "";
            string strBase   = "";
            string strSource = "";
            string sStateMsg = "";

            int i            = 0;
            int nFind        = 0;
            int nSite        = 0;
            int nSiteBack    = 0;
            int nCnt         = 0;
            try
            {
                soutBase  = "";
                nSiteFrom = 0 ;
                nSiteTo   = 0;
                nCount    = 0;

                strSource = sSource;
                strBase   = sBase;
        
                if( strSource == "" )
                {
                    nCount = 0;
                    return "";
                }
 
                int nSourceSize = strSource.Length;
                int nBaseSize   = strBase.Length;

                //마지막에 szBase의 스트링이 없으면 붙여준다.
                //nCnt = GetStrCount( strBase, cFBase.ToString() );
                //for( i = 1; i <= nCnt; ++i )
                //{
                //    sEBase = GetNthStr(strBase, i, cFBase.ToString());
                //    if( strSource.IndexOf( strBase, nSourceSize - sEBase.Length ) != -1 )
                //        break;
                //}

                i = 0;                
                string[] sARet = strBase.Split(cFBase);
                nCnt = GetStrCount( strBase, cFBase.ToString() );
                foreach (string sEntry in sARet)
                {
                    ++i;
                    sEBase = sEntry;
                    if( strSource.IndexOf( strBase, nSourceSize - sEBase.Length ) != -1 )
                        break;
                }

                if( i >= nCnt )
                    strSource += sEBase;
                //마지막에 szBase의 스트링이 없으면 붙여준다.

                while( nSite < nSourceSize )
                {
                    nSite =  FindEx( strSource, strBase, cFBase, out sFBase, nSite );
                    nBaseSize = sFBase.Length;

                    if( nSite != -1 )
                    {
                        ++nFind;
                        if( nFind == nFrom )
                        {
                            for( int j = nSiteBack; j < nSite; ++j )
                                strRet += strSource[j];
                            break;
                        }
                        nSite += nBaseSize;
                        nSiteBack = nSite;
                    }
                    else
                        break;
                }

                nSiteFrom  = nSiteBack;
                nSiteTo    = nSite-1;
                nCount     = nFind;
                soutBase   = sFBase;

                return strRet;
            }
            catch (Exception Err)
            {
                soutBase = "";
                nSiteFrom = 0;
                nSiteTo = 0;
                nCount = 0;

                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::GetStrFromStrEx Catch Error:{0}", sErr);
                return "";
            }
        }



        public static bool IsDigitChar(char cCh)
        {
            int nCh = (int)cCh;
            return ( (nCh >=48 && nCh <= 57) );
        }

        public static bool IsDigitStr(string sString)
        {
            string sStateMsg;
            try
            {
                int nLen = sString.Length;
                if( nLen <= 0 ) return false;

                for( int i = 0; i < nLen; ++i )
                {
                    if( !IsDigitChar( sString[i] ) )
                        return false;
                }
                return true;
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::IsDigitStr Catch Error:{0}", sErr);
                return false;
            }
        }

        public static bool IsAlphaChar(char cCh)
        {
            int nCh = (int)cCh;
            return ( (nCh >=65 && nCh <= 90) || (nCh >=97 && nCh <= 122) );
        }


        public static bool IsETCChar(char cCh)
        {
            int nCh = (int)cCh;
            return ( nCh == 45 || nCh == 91 || nCh == 93 || nCh == 94 || nCh == 95 || nCh == 96 );
        }

        public static bool IsAlphaStr(string sString)
        {
            string sStateMsg;
            try
            {
                int nLen = sString.Length;
                if( nLen <= 0 ) return false;

                for( int i = 0; i < nLen; ++i )
                {
                    if( !IsAlphaChar( sString[i] ) && !IsETCChar(  sString[i] ) )
                        return false;
                }
                return true;
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::IsAlphaStr Catch Error:{0}", sErr);
                return false;
            }
        }

        //sData가 Domain인지를 리턴..
        public static bool IsDomain(string sData)
        {
            string sStateMsg;
            string sProtocal, sVal;
            int nCnt = 0;
            try
            {
                if( sData == "" ) return false;

                sData = sData.Trim();

                sProtocal = GetNthStr(sData, 1, "//");
                if( sProtocal.IndexOf( ":" ) != -1 )
                    sData.Replace( sProtocal + "//", "" );    
                else
                    sData = sProtocal;

                sData = GetNthStr(sData, 1, "/");

                //.뒤가 영어가 아니면 도메인 아님
                //else
                //{
                //  .앞이 영어 or 숫자이면 도메인
                //  아니면 도메인 아님
                //}
        
                nCnt = GetStrCount( sData, "." );
                if( nCnt >= 2 && nCnt <= 4 )
                {
                    //몽땅 숫자이면 숫자 Url Domin
                    if (IsDigitStr(GetNthStr(sData, 1, ".")))
                    {
                        if (IsDigitStr(GetNthStr(sData, 2, ".")))
                        {
                            if (IsDigitStr(GetNthStr(sData, 3, ".")))
                            {
                                sVal = GetNthStr(sData, 4, ".");
                                sVal = GetNthStr(sVal, 1, ":");
                                if( IsDigitStr( sVal ) )
                                    return true;
                            }
                        }
                    }

                    //숫자가 없을 경우..
                    sVal = GetNthStr(sData, nCnt, ".");
                    sVal = GetNthStr(sVal, 1, ":");

                    //마지막이 알파벳이 아니면 도메인이 아님.
                    if( !IsAlphaStr( sVal ) ) return false;


                    sVal = GetNthStr(sData, 1, ".");
                    //sVal중에서도 맨 앞글자가 알파벳이거나 숫자이면 도메인.. -> . 를 구분자로 3개이상 있는 것 중에.. 맨 앞을 판단.
                    return ( IsAlphaChar( sVal[0] ) || IsDigitChar( sVal[0] ) );
                }
                else
                {
                    return ( sData == "localhost" || sData.IndexOf( "localhost:" ) != -1 );
                }
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::IsDomain Catch Error:{0}", sErr);
                return false;
            }
        }

        public static bool IsFindSqlInjuction (string sData)
        {
            if( sData.IndexOf( ";" ) != -1 )  return true;
            if( sData.IndexOf( "+" ) != -1 )  return true;
            if( sData.IndexOf( "#" ) != -1 )  return true;
            if( sData.IndexOf( "--" ) != -1 ) return true;
            if( sData.IndexOf( "'" ) != -1 )  return true;
            if (FindNoCase(sData, "UNION") != -1) return true;
            if (FindNoCase(sData, "SELECT") != -1) return true;
            if (FindNoCase(sData, "INSERT") != -1) return true;
            if (FindNoCase(sData, "UPDATE") != -1) return true;

            return false;
        }
        
        public static bool WildcardCompareNoCase (string strWild, string strText)
        {
            string sStateMsg;
	        int cp = 0, mp = 0;
	        int idxWild = 0, idxString = 0;
	        int nStrLen  = strText.Length;
	        int nWildLen = strWild.Length;
            try
            {
	           if( strWild.IndexOf( "*" ) == -1  &&  strWild.IndexOf( "?" ) == -1 )
                   return (string.Compare(strWild, strText, System.StringComparison.OrdinalIgnoreCase) == 0);

	            while (idxString < nStrLen)
	            {
		            if (idxWild >= nWildLen)
			            break;
		            if (strWild [idxWild] == '*')
			            break;
                    
                    if( ( strWild[idxWild].ToString().ToUpper() != strText[idxString].ToString().ToUpper() ) && (strWild [idxWild] != '?') )
                       return false;
		    
		            ++ idxWild;
		            ++ idxString;
	            }
	    
	            while (idxString < nStrLen) 
	            {
		            if (idxWild >= nWildLen)
			            break;
		    
		            if (strWild [idxWild] == '*') 
		            {
			            ++ idxWild;
			            if (idxWild >= nWildLen)
				            return true;
			    
			            mp = idxWild;
			            cp = idxString + 1;
		            } 
                    else if ( (strWild[idxWild].ToString().ToUpper() == strText[idxString].ToString().ToUpper() ) || (strWild [idxWild] == '?') ) 
                    {
                        ++ idxWild;
                        ++ idxString;
                    }
		            else 
		            {
			            idxWild = mp;
			            idxString = cp ++;
		            }
	            }
	    
	            while (idxWild < nWildLen)
	            {
		            if (strWild [idxWild] != '*')
			            break;
		            ++ idxWild;
	            }
	    
	            return  (idxWild >= nWildLen);
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::WildcardCompareNoCase Catch Error:{0}", sErr);
                return false;
            }
        }

        public static bool WildcardCompare (string strWild, string strText)
        {
            string sStateMsg;
            int cp = 0, mp = 0;
            int idxWild  = 0, idxString = 0;
            int nStrLen  = strText.Length;
            int nWildLen = strWild.Length;
            try
            {
               if( strWild.IndexOf( "*" ) == -1  &&  strWild.IndexOf( "?" ) == -1 ) 
                   return ( strWild == strText );

                while (idxString < nStrLen)
                {
                    if (idxWild >= nWildLen)
                        break;
                    if (strWild [idxWild] == '*')
                        break;
		    
                    if ((strWild [idxWild] != strText [idxString] && (strWild [idxWild] != '?')))
                        return false;
		    
                    ++ idxWild;
                    ++ idxString;
                }
	    
                while (idxString < nStrLen) 
                {
                    if (idxWild >= nWildLen)
                        break;
		    
                    if (strWild [idxWild] == '*') 
                    {
                        ++ idxWild;
                        if (idxWild >= nWildLen)
                            return true;
			    
                        mp = idxWild;
                        cp = idxString + 1;
                    } 
                    else if ((strWild [idxWild] == strText [idxString]) || (strWild [idxWild] == '?')) 
                    {
                        ++ idxWild;
                        ++ idxString;
                    }
                    else 
                    {
                        idxWild = mp;
                        idxString = cp ++;
                    }
                }
	    
                while (idxWild < nWildLen)
                {
                    if (strWild [idxWild] != '*')
                        break;
                    ++ idxWild;
                }
	    
                return (idxWild >= nWildLen);
            }
            catch (Exception Err)
            {
                string sErr = Err.ToString();
                sStateMsg = string.Format("StringParser::WildcardCompare Catch Error:{0}", sErr);
                return false;
            }
        }

        public static string ConvertANSIToUTF8forIE(string sText)
        {
            string sValue;
            string sStateMsg;
            string sRet = "";
            System.Text.Encoding ToEncode = null;
            byte[] utf8Bytes = null;
            try
            {
                ToEncode = System.Text.Encoding.UTF8;

                utf8Bytes = ToEncode.GetBytes(sText);
                foreach (byte b in utf8Bytes)
                {
                    sValue = string.Format("%{0:X2}", b);
                    sRet += sValue;
                }
                return sRet;
            }
            catch (Exception error)
            {
                string sErr = error.ToString();
                sStateMsg = string.Format("<Contents>StringParser::ConvertANSIToUTF8forIE Catch Error {0}<Contents>", sErr);
                return sText;
            }
        }

        //Silverlight는 지원 안함
        #if CShartDotNet
        public static string ConvertANSIToEUCforIE(string sText, int nCodePage)
        {
            string sValue;
            string sStateMsg;
            string sRet = "";
            System.Text.Encoding ToEncode = null;
            byte[] utf8Bytes = null;
            try
            {
                ToEncode = System.Text.Encoding.GetEncoding(nCodePage);
                //ToEncode = System.Text.Encoding.GetEncoding("utf-8");
                //ToEncode = System.Text.Encoding.GetEncoding("utf-16");
                //ToEncode = System.Text.Encoding.GetEncoding("utf-16LE");
                //ToEncode = System.Text.Encoding.GetEncoding("utf-16BE");                

                utf8Bytes = ToEncode.GetBytes(sText);
                foreach (byte b in utf8Bytes)
                {
                    sValue = string.Format("%{0:X}", b);
                    sRet += sValue;
                }
                return sRet;
            }
            catch (Exception error)
            {
                string sErr = error.ToString();
                sStateMsg = string.Format("<Contents>StringParser::ConvertANSIToEUCforIE Catch Error {0}<Contents>", sErr);
                return sText;
            }
        }
        public static string ConvertUrlDecoding(string sUrl)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(sUrl)) != sUrl)
            {
                sUrl = newUrl;
            }
            return sUrl;
        }

        public static bool IsUniCode(String value)
        {
            byte[] ascii   = AsciiStringToByteArray(value);
            byte[] unicode = UnicodeStringToByteArray(value);
            string value1  = FromASCIIByteArray(ascii);
            string value2  = FromUnicodeByteArray(unicode);
            return (value1 != value2);
        }

        public static bool IsUnicode(byte[] byteData)
        {
            string value1  = FromASCIIByteArray(byteData);
            string value2  = FromUnicodeByteArray(byteData);
            byte[] ascii   = AsciiStringToByteArray(value1);
            byte[] unicode = UnicodeStringToByteArray(value2);
            return (ascii[0] != unicode[0]);
        }

        public static String FromASCIIByteArray(byte[] characters)
        {
            ASCIIEncoding encoding   = new ASCIIEncoding();
            String constructedString = encoding.GetString(characters);
            return constructedString;
        }

        public static String FromUnicodeByteArray(byte[] characters)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            String constructedString = encoding.GetString(characters);
            return constructedString;
        }

        public static byte[] AsciiStringToByteArray(String str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        public static byte[] UnicodeStringToByteArray(String str)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            return encoding.GetBytes(str);
        }
        #endif

        //!Return  :\r\n
        //!Param   :sMsg: 이벤트 로그를 남길 메시지\r\n
        //          sFilePath: 이벤트로그를 발생시킬 파일 경로및 파일 이름
        //          nLine: 이벤트로그를 발생시킨 라인 수
        //          nEventType :
        //          EventLogType.eventlog_error_type
        //          EventLogType.eventlog_information_type
        //          EventLogType.eventlog_user_information_type
        //          EventLogType.eventlog_warning_type
        //          sLogFilePath: 로그파일 이름
        //!Remark  :

        //C#
        //const string LOGFILENAME = (string)ConfigurationManager.AppSettings["LogPath"];
        //string sStateMsg;
        //System.Diagnostics.StackTrace st = null;
        //System.Diagnostics.StackFrame sf = null;
        //try
        //{
        //    st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
        //    sf = st.GetFrame(0);

        //}
        //catch (Exception error)
        //{
        //    string sErr = error.ToString();
        //    sStateMsg = string.Format("ClassName::FuncName Catch Error : {0}", sErr );
        //    SuperString.StringParser.LogTrace(sStateMsg, sf.GetFileName(), sf.GetFileLineNumber(), (int)SuperString.StringParser.EventLogType.eventlog_error_type, LOGFILENAME );
        //}

        //Silverlight OOB
        //const string LOGFILENAME = "C:\\Temp\\";
        //string sStateMsg;
        //try
        //{

        //}
        //catch (Exception error)
        //{
        //    string sErr = error.ToString();
        //    sStateMsg = string.Format("ClassName::FuncName Catch Error : {0}", sErr );
        //    SuperString.StringParser.LogTrace(sStateMsg, "FileName", 0, (int)SuperString.StringParser.EventLogType.eventlog_error_type, LOGFILENAME );
        //}
    
        ////Silverlight IE -> Default.htm 에 아래와 같이 추가 
        //<script type="text/javascript">
        //var pbjWPLog;
        //objWPLog    = new ActiveXObject('WPLog.SinkLog.1');

        //function LogTrace(nEnentType, sMessage, sLogFilePath)
        //{
        //    var sRet;
        //    try
        //    {
        //        return objWPLog.Report(nEnentType, 1, 1, sMessage, sLogFilePath);
        //    }
        //    catch (e) 
        //    {
        //        return 0;
        //    }
        //}


        //[DllImport("kernel32.dll") ]
        //[PreserveSig]
        //public static extern IntPtr GetModuleHandle(string lpModuleName);
        //[DllImport("kernel32.dll")]
        //public extern static int GetModuleFileName(System.IntPtr hModule, StringBuilder strFullPath, int nSize);


        public static bool LogTrace(string sMsg, string sFilePath, int nLine, int nEventType, string sLogFilePath)
        {
            return LogTrace(sMsg, "", sFilePath, nLine, nEventType, sLogFilePath);
        }

        public static bool LogTrace(string sMsg, string sFunc, string sFilePath, int nLine, int nEventType, string sLogFilePath)
        {
            return LogTrace(sMsg, sFunc, 1, sFilePath, nLine, nEventType, sLogFilePath);
        }

        //static private void T_BlockingChk(object oParam)
        //{
        //    try
        //    {
        //        StringParserBlocking BlockingChk = oParam as StringParserBlocking;

        //        while (true)
        //        {
        //            if (!BlockingChk.bBlocking) return;

        //            for (long i = 0; i < 600; ++i)
        //            {
        //                if (!BlockingChk.bBlocking) return;
        //                Thread.Sleep(50);
        //            }
        //            FileIO.GeneralIO.KillProc("WPSLog");
        //            return;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {            	
        //    } 
        //}


        public static bool LogTrace(string sMsg, string sFunc, int nEvtID, string sFilePath, int nLine, int nEventType, string sLogFilePath)
        {
            try
            {
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }


        //bForTransfer == true일 경우 서버로 전송되기 위한것으로, + \r \n 문자를 치환한다.
        //public static string Base64Decode(string src, System.Text.Encoding enc, bool bForTransfer = false)
        //{
        //    if (string.IsNullOrEmpty(src)) return "";

        //    if (bForTransfer)
        //    {
        //        src = src.Replace("ItisPlus", "+");
        //        src = src.Replace("ItisNeun", "=");
        //        src = src.Replace("ItisBackR", "\r");
        //        src = src.Replace("ItisBackN", "\n");
        //    }

        //    byte[] arr = Convert.FromBase64String(src);

        //    #if CShartDotNet
        //        return enc.GetString(arr);
        //    #else
        //        return ByteToString(arr, arr.Length);
        //    #endif            
        //}

        //bForTransfer == true일 경우 서버로 전송되기 위한것으로, + \r \n 문자를 치환한다.
        public static string Base64Encode(string src, System.Text.Encoding enc, bool bForTransfer = false)
        {
            if (string.IsNullOrEmpty(src)) return "";

            byte[] arr = enc.GetBytes(src);
            string sRet = Convert.ToBase64String(arr);
            if (bForTransfer)
            {
                sRet = sRet.Replace("+", "ItisPlus");
                sRet = sRet.Replace("=", "ItisNeun");
                sRet = sRet.Replace("\r", "ItisBackR");
                sRet = sRet.Replace("\n", "ItisBackN");
            }
            return sRet;
        }

        public static byte[] Base64DecodeToByte(string src, bool bForTransfer = false)
        {
            if (string.IsNullOrEmpty(src)) return null;

            if (bForTransfer)
            {
                src = src.Replace("ItisPlus", "+");
                src = src.Replace("ItisNeun", "=");
                src = src.Replace("ItisBackR", "\r");
                src = src.Replace("ItisBackN", "\n");
            }

            return Convert.FromBase64String(src);
        }


        //bForTransfer == true일 경우 서버로 전송되기 위한것으로, + \r \n 문자를 치환한다.
        public static string Base64DecodeToString(string src, bool bForTransfer = false)
        {
            if (string.IsNullOrEmpty(src)) return "";

            if (bForTransfer)
            {
                src = src.Replace("ItisPlus", "+");
                src = src.Replace("ItisNeun", "=");
                src = src.Replace("ItisBackR", "\r");
                src = src.Replace("ItisBackN", "\n");
            }

            byte[] arr = Convert.FromBase64String(src);
            return UTF8Encoding.UTF8.GetString(arr, 0, arr.Length);
        }


        //bForTransfer == true일 경우 서버로 전송되기 위한것으로, + \r \n 문자를 치환한다.
        public static string Base64Decode(string src, bool bForTransfer = false)
        {
            return Base64DecodeToString(src, bForTransfer);
        }

        public static string Base64EncodeFromByte(byte[] src, bool bForTransfer = false)
        {
            string sRet = "";
            if (src == null) return "";
            sRet = Convert.ToBase64String(src);
            if (bForTransfer)
            {
                sRet = sRet.Replace("+", "ItisPlus");
                sRet = sRet.Replace("=", "ItisNeun");
                sRet = sRet.Replace("\r", "ItisBackR");
                sRet = sRet.Replace("\n", "ItisBackN");
            }
            return sRet;
        }

        //bForTransfer == true일 경우 서버로 전송되기 위한것으로, + \r \n 문자를 치환한다.
        public static string Base64EncodeFromString(string src, bool bForTransfer = false)
        {
            if (string.IsNullOrEmpty(src)) return "";

            byte[] arr = UTF8Encoding.UTF8.GetBytes(src);
            string sRet = Convert.ToBase64String(arr);
            if (bForTransfer)
            {
                sRet = sRet.Replace("+", "ItisPlus");
                sRet = sRet.Replace("=", "ItisNeun");
                sRet = sRet.Replace("\r", "ItisBackR");
                sRet = sRet.Replace("\n", "ItisBackN");
            }
            return sRet;
        }

        //bForTransfer == true일 경우 서버로 전송되기 위한것으로, + \r \n 문자를 치환한다.
        public static string Base64Encode(string src, bool bForTransfer = false)
        {
            return Base64EncodeFromString(src, bForTransfer);
        }

        public static string ToHexString(string str)
        {
            try
            {
                var sb = new StringBuilder();

                var bytes = Encoding.Unicode.GetBytes(str);
                foreach (var t in bytes)
                {
                    sb.Append(t.ToString("X2"));
                }

                return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
            }
            catch (System.Exception ex)
            {
                return "";
            }            
        }

        public static string FromHexString(string hexString)
        {
            try
            {
                var bytes = new byte[hexString.Length / 2];
                for (var i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                }

                return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
            }
            catch (System.Exception ex)
            {
                return "";
            }

        }
    }
}
