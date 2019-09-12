using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticalDebugingDemos
{
    public abstract class DemoBase : MVVMC.BaseViewModel
    {
        public virtual string Caption =>GetCaptionFromClassName();

        protected string GetCaptionFromClassName()
        {
            var str = this.GetType().Name;
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
        }

        private object _content;
        public object Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged();}
        }

        //protected TextB


        public abstract void Start();

        public override string ToString()
        {
            return Caption;
        }
    }
}
