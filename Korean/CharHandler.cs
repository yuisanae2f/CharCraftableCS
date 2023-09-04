using System;
namespace yuisanae2f.CharCraftableCS.Korean
{
    public class CharHandler : Craftable<char>
    {
        private char _c;

        public static string UPPER_VOWELS { get { return "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ"; } }

        public static string VOWELS { get { return "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ"; } }

        public static string UNDER_VOWELS { get { return " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ"; } }

        private int _un;
        private int _v;
        private int _up;

        public char underVowel
        {
            get { return UNDER_VOWELS[_un]; }
            set
            {
                int i = 0;
                if (!UNDER_VOWELS.Contains(value)) return;
                for (char c = value; UNDER_VOWELS[i] != c; i++) { }

                this.value = (char)(this.value + i - _un);

                _un = i;
            }
        }

        public char vowel
        {
            get { return VOWELS[_v]; }
            set
            {
                int i = 0;
                if (!VOWELS.Contains(value)) return;
                for (char c = value; VOWELS[i] != c; i++) { }

                this.value = (char)(this.value + UNDER_VOWELS.Length * (i - _v));

                _v = i;
            }
        }

        public char upperVowel
        {
            get { return UPPER_VOWELS[_up]; }
            set
            {
                int i = 0;
                if (!UPPER_VOWELS.Contains(value)) return;
                for (char c = value; UPPER_VOWELS[i] != c; i++) { }

                this.value = (char)(this.value + VOWELS.Length * UNDER_VOWELS.Length * (i - _up));

                _up = i;
            }
        }

        public char value
        {
            get { return _c; }
            set
            {
                _c = value;
                int _ = _c - '가';
                _un = _ % UNDER_VOWELS.Length;
                _ /= UNDER_VOWELS.Length;

                _v = _ % VOWELS.Length;
                _ /= VOWELS.Length;

                _up = _ % UPPER_VOWELS.Length;
            }
        }

        public string shredded { get { return upperVowel.ToString() + vowel.ToString() + underVowel.ToString(); } }

        public CharHandler(char c)
        {
            value = c;
        }
    }
}

// © 2023. YuiSanae2f