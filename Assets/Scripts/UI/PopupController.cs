using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnExit()
    {
        //Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }

    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Open()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
