using System;
using Assets.Scripts.Entities;
using Assets.Scripts.Models;
using Assets.Scripts.Services;

namespace Assets.Scripts.Controllers
{
    public class CreateProfileController : ProfileController
    {
        public void CreateUser()
        {
            errorInfo.SetActive(false);
            string login = loginText.text;
            try
            {
                VerifyService.VerifyString(login);
                LoadUsers();
                VerifyUser(login);
                AddUser(login);
            }
            catch (Exception e)
            {
                errorText.text = e.Message;
                errorInfo.SetActive(true);
                return;
            }
            profileMenu.SetActive(false);
            chooseLevelMenu.SetActive(true);
        }
	
        private void AddUser(string login)
        {
            var user = new User {Login = login};
            GlobalData.Instance.CurrentUser = user;
            GlobalData.Instance.Users.Add(user);
            SaveUsers();
        }

        private void VerifyUser(string login)
        {
            if (FindUser(login) != null)
                throw new Exception("Користувач з логіном " + login + " вже існує. Задайте інший логін");
        }
    }
}
