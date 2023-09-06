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
            get { return _un == -1 ? ' ' : UNDER_VOWELS[_un]; }
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
            get { return _v == -1 ? ' ' : VOWELS[_v]; }
            set
            {
                if (value == ' ')
                {
                    this.value = ' ';
                    return;
                }

                int i = 0;
                if (!VOWELS.Contains(value)) return;
                for (char c = value; VOWELS[i] != c; i++) { }

                this.value = (char)(this.value + UNDER_VOWELS.Length * (i - _v));

                _v = i;
            }
        }

        public char upperVowel
        {
            get {
                return _up == -1 ? ' ' : UPPER_VOWELS[_up]; 
            }
            set
            {
                if(value == ' ')
                {
                    this.value = ' ';
                    return;
                }

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
                if (value == ' ')
                {
                    _v = _up = _un = -1;
                    _c = ' ';
                    return;
                }

                _c = value;
                int _ = _c - '가';
                _un = _ % UNDER_VOWELS.Length;
                _ /= UNDER_VOWELS.Length;

                _v = _ % VOWELS.Length;
                _ /= VOWELS.Length;

                _up = _ % UPPER_VOWELS.Length;
            }
        }

        public static bool isKorean(string shredded)
        {
            return 
                shredded.Length == 3
                && UPPER_VOWELS.Contains(shredded[0])
                && VOWELS.Contains(shredded[1])
                && UNDER_VOWELS.Contains(shredded[2])
                || shredded[0] == ' ' && shredded[1] == ' ' && shredded[2] == ' '
                ;
        }

        public string shredded { 
            get { 
                return _c == ' ' ? "   " : upperVowel.ToString() + vowel.ToString() + underVowel.ToString(); 
            } 
            set
            {
                string _ = value;
                if (value == "   ")
                {
                    _v = _up = _un = -1;
                    _c = ' ';
                    return;
                }

                if (!isKorean(_)) return;

                upperVowel = _[0];
                vowel = _[1];
                underVowel = _[2];
            }
        }

        public CharHandler(char c)
        {
            value = c;
        }
    }
}

// © 2023. YuiSanae2f