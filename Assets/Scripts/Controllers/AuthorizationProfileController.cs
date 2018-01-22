using System;
using Assets.Scripts.Models;
using Assets.Scripts.Services;

namespace Assets.Scripts.Controllers
{
    public class AuthorizationProfileController : ProfileController
    {
        public void RecogniseUser()
        {
            errorInfo.SetActive(false);
            string login = loginText.text;
            try
            {
                VerifyService.VerifyString(login);
                LoadUsers();
                Recognise(login);
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

        private void Recognise(string login)
        {
            var user = FindUser(login);
            if (user == null)
                throw new Exception("Користувач з логіном " + login + " не існує.");
            GlobalData.Instance.CurrentUser = user;
        }
    }
}
