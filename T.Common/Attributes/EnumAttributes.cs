using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Common.Attributes
{
    /// <summary>
    /// 枚举CSS样式属性
    /// </summary>
    public class CssAttribute : Attribute
    {
        public string Css { get; set; }

        public CssAttribute(string css)
        {
            this.Css = css;
        }
    }
}
