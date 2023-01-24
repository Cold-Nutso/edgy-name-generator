using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgy_Name_Generator
{
    static class Global
    {
        private static EditorForm editor = null;
        public static EditorForm Editor { get { return editor; } set { editor = value; } }
    }
}
