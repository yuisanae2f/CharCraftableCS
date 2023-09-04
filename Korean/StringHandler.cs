using System;
namespace yuisanae2f.CharCraftableCS.Korean
{
    /// <summary>
    /// asdfffff
    /// </summary>
    public class StringHandler : Craftable<string>
    {
        private CharHandler[] _str;
        public string shredded
        {
            get
            {
                string _ = "";
                foreach (CharHandler e in _str) { _ += e.shredded; }
                return _;
            }
        }

        public string value
        {
            get
            {
                string _ = "";
                foreach (CharHandler k in _str) { _ += k.value; }
                return _;
            }
            set
            {
                List<CharHandler> ks = new List<CharHandler>();
                foreach (char c in value)
                {
                    ks.Add(new(c));
                    _str = ks.ToArray();
                }
            }
        }

        /// <summary>
        /// asdffff
        /// </summary>
        /// <param name="str">asdf</param>
        public StringHandler(string str)
        {
            List<CharHandler> _ = new List<CharHandler>();
            foreach (char c in str) { _.Add(new(c)); }
            _str = _.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public StringHandler(CharHandler[] c) { _str = c; }
    }
}

// © 2023. YuiSanae2f