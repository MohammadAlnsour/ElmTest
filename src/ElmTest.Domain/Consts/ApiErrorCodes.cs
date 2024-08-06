namespace ElmTest.Domain.Consts
{
    public static class ApiErrorCodes
    {
        public static KeyValuePair<string, string> BookTitleRequired { get => new KeyValuePair<string, string>("001", "BookTitle field is required."); }
        public static KeyValuePair<string, string> BookTitleLengthNotCorrect { get => new KeyValuePair<string, string>("002", "BookTitle field length not correct."); }
    }
}
