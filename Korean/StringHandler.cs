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

            set
            {
                string _ = value;
                int len = _.Length;
                List<CharHandler> r = new List<CharHandler>();

                if (len % 3 != 0) return;

                for(int i = 0; i < len; i+=3)
                {
                    CharHandler __ = new CharHandler('가');
                    if(!(CharHandler.isKorean(_[i + 0].ToString() + _[i + 1].ToString() + _[i + 2].ToString()))) return;
                    __.upperVowel = _[i + 0];
                    __.vowel = _[i + 1];
                    __.underVowel = _[i + 2];
                    r.Add(__);
                }

                _str = r.ToArray();
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