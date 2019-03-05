using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Filter : BaseFilter
    {
        /// <summary>
        /// 在文本中替换所有的关键字
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="replaceChar">替换符</param>
        /// <returns></returns>
        public string Replace(string text,  char replaceChar = '*')
        {
            StringBuilder result = new StringBuilder(text.ToLower());
            var p = 0;

            for (int i = 0; i < text.Length; i++)
            {
                var t = (char)_dict[text[i]];
                if (t == 0)
                {
                    p = 0;
                    continue;
                }
                var next = _next[p] + t;
                bool find = _key[next] == t;
                if (find == false && p != 0)
                {
                    p = 0;
                    next = _next[p] + t;
                    find = _key[next] == t;
                }
                if (find)
                {
                    var index = _check[next];
                    if (index > 0)
                    {
                        var maxLength = _keywords[_guides[index][0]].Length;
                        var start = i + 1 - maxLength;
                        var word = text.Substring(start, maxLength);//敏感词
                        for (int j = start; j <= i; j++)
                        {
                            result[j] = replaceChar;
                        }
                    }
                    p = next;
                }
            }
            return result.ToString();
        }
    }
}
