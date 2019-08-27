using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLauncher
{
    public class PatchCombineFix
    {
        public static string PatchCombine(string s1, string s2)
        {
            return s1 + @"/" + s2;
        }
        public static string PatchCombine(string s1, string s2, string s3)
        {
            string tmp = PatchCombine(s1, s2);

            return PatchCombine(tmp, s3);
        }
        public static string PatchCombine(string s1, string s2, string s3, string s4)
        {
            string tmp = PatchCombine(s1, s2);

            return PatchCombine(tmp, s3, s4);
        }
        public static string PatchCombine(string s1, string s2, string s3, string s4, string s5)
        {
            string tmp = PatchCombine(s1, s2);

            return PatchCombine(tmp, s3, s4, s5);
        }
    }
}
