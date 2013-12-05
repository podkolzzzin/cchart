using System;
using System.Collections.Generic;
using System.Linq;

namespace DronovsCharts.Analyze
{
    static class StringExtensions
    {
        public static string ToArrStr(this string[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
                result += "" + i + "=>" + arr[i] + "\r\n";

            return result;
        }

        public static void Remove(this string[] arr, params char[] symbols)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                foreach (var symbol in symbols)
                {
                    arr[i] = arr[i].Replace(symbol.ToString(), "");
                }
            }
        }

        public static string[] OperatorSplit(this string str)
        {
            List<String> pList = new List<string>();
            int difficult = 0, inside = 0;
            int prev = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case '{':
                        difficult++;
                        break;
                    case '}':
                        difficult--;
                        if (difficult == 0)
                        {
                            if (i - prev + 1 > 1)
                                pList.Add(str.Substring(prev, i - prev + 1));
                            prev = i + 1;
                        }
                        break;
                    case '(':
                        inside++;
                        break;
                    case ')':
                        inside--;
                        break;
                }
                
                if (difficult==0 && c == ';' && inside==0)
                {
                    if (i - prev > 0)
                    {
                        string s = str.Substring(prev, i - prev);
                        s = s.Trim();
                        if(s.Length>0)
                            pList.Add(s);
                    }
                    prev = i + 1;
                }
            }

            if (str.Length - prev > 0)
            {
                string last = str.Substring(prev).Trim();
                if(last!="}" && last.Length>0)
                    pList.Add(last);
            }

            for (int index = 0; index < pList.Count; index++)
            {
                pList[index] = pList[index].Trim(' ', '\r', '\n', '\t');
            }

            return pList.ToArray();
        }

        public static string ToArrStr(this List<COperator> r)
        {
            return r.Aggregate("", (current, v) => current + (v.ToString() + "\r\n"));
        }

        public static string ToSpecString(this string[] strs, char spec)
        {
            return string.Join(spec.ToString(), strs);
        }

        public static bool StartsWith(this string c, params string[] strs)
        {
            return strs.Any(s => c.StartsWith(s));
        }

        public static int BlockBeetweenEnd(this string src, char start, char end)
        {
            int n = 0;
            int iStart = -1;
            for (int index = 0; index < src.Length; index++)
            {
                var c = src[index];
                if (c == start)
                {
                    n++;
                    if (iStart == -1)
                        iStart = index;
                }
                else if (c == end)
                    n--;

                if (n == 0 && iStart >= 0)
                {
                    return index;
                }
            }
            return -1;          
        }

        public static string BlockBeetween(this string src, char start, char end)
        {
            int s = src.IndexOf(start) + 1;
            int e = src.BlockBeetweenEnd(start, end);
            return e == -1 ? src : src.Substring(s, e - s);
        }

        public static string Beetween(this string src, string sStart, string sEnd)
        {
            if (sStart == "(" || sStart == "{")
                return BlockBeetween(src, sStart[0], sEnd[0]);
            int start = src.IndexOf(sStart);
            if (start == -1)
                return src;
            int end = src.LastIndexOf(sEnd);
            return src.Substring(start + 1, end - start - 1);
        }
    }
}
