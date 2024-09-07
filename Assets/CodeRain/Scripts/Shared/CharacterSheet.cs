namespace DOTSessions.CodeRain.Shared
{
    public static class CharacterSheet
    {
        private static readonly string[] Characters = new string[]
            {
                // kanji
                '\u65e5'.ToString(),

                // katakana
                '\uff8a'.ToString(),
                '\uff90'.ToString(),
                '\uff8b'.ToString(),
                '\uff70'.ToString(),
                '\uff73'.ToString(),
                '\uff7c'.ToString(),
                '\uff85'.ToString(),
                '\uff93'.ToString(),
                '\uff86'.ToString(),
                '\uff7b'.ToString(),
                '\uff9c'.ToString(),
                '\uff82'.ToString(),
                '\uff75'.ToString(),
                '\uff98'.ToString(),
                '\uff71'.ToString(),
                '\uff8e'.ToString(),
                '\uff83'.ToString(),
                '\uff8f'.ToString(),
                '\uff79'.ToString(),
                '\uff92'.ToString(),
                '\uff73'.ToString(),
                '\uff76'.ToString(),
                '\uff77'.ToString(),
                '\uff91'.ToString(),
                '\uff95'.ToString(),
                '\uff97'.ToString(),
                '\uff7e'.ToString(),
                '\uff88'.ToString(),
                '\uff7d'.ToString(),
                '\uff80'.ToString(),
                '\uff87'.ToString(),
                '\uff8d'.ToString(),
                '\uff66'.ToString(),
                '\uff72'.ToString(),
                '\uff78'.ToString(),
                '\uff7a'.ToString(),
                '\uff7f'.ToString(),
                '\uff81'.ToString(),
                '\uff84'.ToString(),
                '\uff89'.ToString(),
                '\uff8c'.ToString(),
                '\uff94'.ToString(),
                '\uff96'.ToString(),
                '\uff99'.ToString(),
                '\uff9a'.ToString(),

                // numbers 
                '0'.ToString(),
                '6'.ToString(),
                '8'.ToString(),
                '9'.ToString(),

                // special characters
                '\u003a'.ToString(),
                '\u30fb'.ToString(),
                '\u002e'.ToString(),
                '\u0022'.ToString(),
                '\u003d'.ToString(),
                '\u002a'.ToString(),
                '\u002b'.ToString(),
                '\u002d'.ToString(),
                '\u003c'.ToString(),
                '\u003e'.ToString(),

                // other
                '\u00a6'.ToString(),
                '\uff5c'.ToString(),
                '\u00e7'.ToString(),
    
                // roman
                'Z'.ToString()
            };

        public static int AvailableCharactersCount => Characters.Length;

        public static string GetCharacter(int index)
        {
            return index < 0 || index >= AvailableCharactersCount ? '\0'.ToString() : Characters[index];
        }
    }
}
