using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Entities;

namespace Assets.Scripts.Models
{
    public class GlobalData
    {
        #region Singelton

        private static GlobalData _instance;

        public static GlobalData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GlobalData();
                return _instance;
            }
        }

        private GlobalData()
        {
            Users = new List<User>();
            string currentDirectory = Directory.GetCurrentDirectory();
            UsersPath = Path.Combine(currentDirectory, usersPath);
            ResultsPath = Path.Combine(currentDirectory, resultsPath);
        }

        #endregion

        #region Path
        private readonly string usersPath = @"Resources\Users\users.json";
        private readonly string resultsPath = @"Resources\Results\results.json";

        public string UsersPath { get; set; }
        public string ResultsPath { get; set; }
        #endregion

        #region Data
        public List<User> Users { get; set; }
        public User CurrentUser { get; set; }
        public List<UserScore> UserScores { get; set; }
        #endregion

    }
}
