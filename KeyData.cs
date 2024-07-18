using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod4x_fixer
{
    public class KeyData
    {
        public string Key { get; set; }
        public string User { get; set; }

        public override string ToString()
        {
            return $"{Key} - {User}";
        }
    }

}
