using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class WinController : MonoBehaviour {


    private int money = 0;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToMap()
    {
        gameObject.SetActive(false);
        //PlayerPrefs.SetFloat("score", money);
        //ScoreManager.score = money;
        Messenger<int>.Broadcast(GameEvent.PLAYER_WIN, money);
        SceneManager.LoadScene("MainMenu");
        
    }

    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.MONEY_CHANGED, OnMoneyChanged);
    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.MONEY_CHANGED, OnMoneyChanged);
    }

    private void OnMoneyChanged(int value)
    {
        money += value;
    }

}
