using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos
{
    public abstract class DemoBase : MVVMC.BaseViewModel
    {
        public virtual string Caption =>GetCaptionFromClassName();

        protected string GetCaptionFromClassName()
        {
            var str = this.GetType().Name;
            return CamelCaseToFriendlyString(str);
        }

        private static string CamelCaseToFriendlyString(string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
        }

        public string Category => CamelCaseToFriendlyString(this.GetType().Namespace.Split('.').Last());

        private object _content;
        public object Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged();}
        }

        public void ClearContent()
        {
            Content = null;
        }


        public void AppendTextToContent(object text)
        {
            if (Content == null)
                Content = "";
            Content = (string)Content + "\n" + text.ToString();
            
        }

        public void AppendTextToContent(string format, object arg0)
        {
            AppendTextToContent(string.Format(format, arg0));
        }

        public void AppendTextToContent(string format, object arg0, object arg1)
        {
            AppendTextToContent(string.Format(format, arg0, arg1));
        }


        public abstract void Start();

        public override string ToString()
        {
            return Caption;
        }
    }
}
