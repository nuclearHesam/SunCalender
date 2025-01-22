namespace Services
{
    public static class ChangeCharacters
    {
        public static string ChangeChars(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            char[] persianDigits = ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'];

            var result = new System.Text.StringBuilder(text.Length);

            foreach (char c in text)
            {
                if (char.IsDigit(c) && c >= '0' && c <= '9')
                {
                    result.Append(persianDigits[c - '0']);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
