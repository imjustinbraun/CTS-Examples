namespace CTSMultiUserErr
{
    public class creds
    {
        public string UserID { get; private set; }
        public string Firm { get; private set; }
        public string Password { get; private set; }

        public static creds BBTest1 => new("BBTest1", "CTSDev", "Winter23$");
        public static creds BBTest2 => new("BBTest2", "CTSDev", "Winter23$");
        public static creds BBTest3 => new("BBTest3", "CTSDev", "Winter23$");
        public static creds BBAdminTest => new("BBAdminTest", "CTSDev", "Tem123$");

        private creds(string userID, string firm, string password)
        {
            UserID = userID;
            Firm = firm;
            Password = password;
        }
    }
}