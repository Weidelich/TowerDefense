namespace Assets.Scripts.Entities
{
    public class UserScore
    {
        public string Login { get; set; }
        public int Total { get; set; }
    }

    [System.Serializable]
    public class UserScoreJSON
    {
        public string user;
        public int total;
    }
}
