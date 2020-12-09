namespace Day04.BL
{
    internal class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }
        public bool StrictValid { get; set; } = true;

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(BirthYear) ||
                string.IsNullOrEmpty(IssueYear) ||
                string.IsNullOrEmpty(ExpirationYear) ||
                string.IsNullOrEmpty(Height) ||
                string.IsNullOrEmpty(HairColor) ||
                string.IsNullOrEmpty(EyeColor) ||
                string.IsNullOrEmpty(PassportID))
                return false;
            return true;
        }
    }
}
