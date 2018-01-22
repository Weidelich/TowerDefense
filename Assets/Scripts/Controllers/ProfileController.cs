using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities;
using Assets.Scripts.Models;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public abstract class ProfileController : MonoBehaviour
    {
        [SerializeField] protected Text loginText = null;
        [SerializeField] protected GameObject profileMenu = null;
        [SerializeField] protected GameObject chooseLevelMenu = null;
        [SerializeField] protected GameObject errorInfo = null;
        [SerializeField] protected Text errorText = null;

        protected List<User> users;

        protected User FindUser(string login)
        {
            return GlobalData.Instance.Users.FirstOrDefault(user => user.Login == login);
        }

        protected void LoadUsers()
        {
            string jsonString = JsonHelper.LoadJson(GlobalData.Instance.UsersPath);
            var userJsons = JsonHelper.GetJsonArray<UserJSON>(jsonString).ToList();
            users = new List<User>();
            foreach (var userJson in userJsons) users.Add(new User() { Login = userJson.user });
            GlobalData.Instance.Users = users;
        }

        protected void SaveUsers()
        {
            List<UserJSON> userJsons = new List<UserJSON>();
            users = GlobalData.Instance.Users;
            foreach (var user in users) userJsons.Add(new UserJSON { user = user.Login });
            string jsonString = JsonHelper.ArrayToJson<UserJSON>(userJsons.ToArray());
            JsonHelper.SaveJson(GlobalData.Instance.UsersPath, jsonString);
        }
    }
}
