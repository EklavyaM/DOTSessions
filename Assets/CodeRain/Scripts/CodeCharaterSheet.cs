using UnityEngine;

namespace DOTSessions.CodeRain
{
    public static class CodeCharaterSheet
    {
        private static readonly char[] CharacterSheet = new char[]
            {
                // kanji
                '\u65e5',

                // katakana
                '\uff8a',
                '\uff90',
                '\uff8b',
                '\uff70',
                '\uff73',
                '\uff7c',
                '\uff85',
                '\uff93',
                '\uff86',
                '\uff7b',
                '\uff9c',
                '\uff82',
                '\uff75',
                '\uff98',
                '\uff71',
                '\uff8e',
                '\uff83',
                '\uff8f',
                '\uff79',
                '\uff92',
                '\uff73',
                '\uff76',
                '\uff77',
                '\uff91',
                '\uff95',
                '\uff97',
                '\uff7e',
                '\uff88',
                '\uff7d',
                '\uff80',
                '\uff87',
                '\uff8d',
                '\uff66',
                '\uff72',
                '\uff78',
                '\uff7a',
                '\uff7f',
                '\uff81',
                '\uff84',
                '\uff89',
                '\uff8c',
                '\uff94',
                '\uff96',
                '\uff99',
                '\uff9a',

                // numbers 
                '0',
                '6',
                '8',
                '9',

                // special characters
                '\u003a',
                '\u30fb',
                '\u002e',
                '\u0022',
                '\u003d',
                '\u002a',
                '\u002b',
                '\u002d',
                '\u003c',
                '\u003e',

                // other
                '\u00a6',
                '\uff5c',
                '\u00e7',

                // roman
                'Z'
            };

        public static int AvailableCharactersCount => CharacterSheet.Length;

        public static char GetCharacter(int index)
        {
            return index < 0 || index >= AvailableCharactersCount ? '\0' : CharacterSheet[index];
        }

        public static char GetRandomCharacter()
        {
            return CharacterSheet[Random.Range(0, AvailableCharactersCount)];
        }

    }
}
