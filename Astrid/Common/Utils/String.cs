using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrid.Common.Utils {
     public class String {
        public static string RemoveSpacesOfHead(string str) {
            string r = str;
            while (BeginsWithSpace(str)){
                r = RemoveOneSpaceOfHead(str);
            }
            return r;
        }

        public static string RemoveOneSpaceOfHead(string str) {
            if (BeginsWithSpace(str)) {
                return str.Substring(1);
            }
            return str;
        }
        private static bool BeginsWithSpace(string str) {
            return str.Substring(0, 1).Equals(" ");
        }
    }
}
