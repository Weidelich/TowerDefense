using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Entities;
using Assets.Scripts.Models;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ResultController : MonoBehaviour
    {
        [SerializeField]
        private Text infoText = null;

        protected List<UserScore> userScores;

        // Use this for initialization
        void Start ()
        {
            LoadUsers();
        }
	
        // Update is called once per frame
        void Update () {
        }

        protected void LoadUsers()
        {
            string jsonString = JsonHelper.LoadJson(GlobalData.Instance.ResultsPath);
            var userScoresJson = JsonHelper.GetJsonArray<UserScoreJSON>(jsonString).ToList();
            userScores = new List<UserScore>();
            foreach (var userScoreJson in userScoresJson)
                userScores.Add(new UserScore() { Login = userScoreJson.user, Total = userScoreJson.total});
            userScores = userScores.OrderByDescending(score => score.Total).ToList();
            GlobalData.Instance.UserScores = userScores;

            var scoreTable = new StringBuilder();
            scoreTable.AppendLine(String.Format("{0,4} {1,10} {2,10}", "#", "Користувач", "Очки"));
            for (int i = 0; i < userScores.Count; i++)
                scoreTable.AppendLine(String.Format("{0,3}) {1,-20} {2,-20}", i + 1, userScores[i].Login, userScores[i].Total));
            infoText.text = scoreTable.ToString();

        }

        public void SaveScore(int score)
        {
            //Debug.Log(GlobalData.Instance.CurrentUser.Login + " " + score);
            string jsonString = JsonHelper.LoadJson(GlobalData.Instance.ResultsPath);
            var userScoresJSON = JsonHelper.GetJsonArray<UserScoreJSON>(jsonString).ToList();
            //userScores = new List<UserScore>();
            userScoresJSON.Add(new UserScoreJSON() { user = GlobalData.Instance.CurrentUser.Login, total = score});
            //userScores = userScores.OrderByDescending(sc => sc.Total).ToList(); 
            jsonString = JsonHelper.ArrayToJson<UserScoreJSON>(userScoresJSON.ToArray());
            //Debug.Log(jsonString);
            JsonHelper.SaveJson(GlobalData.Instance.ResultsPath, jsonString);
        }

        
    }
}
