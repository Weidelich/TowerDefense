using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text moneyText;
    [SerializeField] private PopupController popup;
    [SerializeField] private LoseController lose;
    [SerializeField] private WinController win;

    private List<GameObject> lifes;
    private int money = 0;
    private bool isInsufficient = false;
    private bool isNoEnemies = false;
	// Use this for initialization
	void Start () {
        lifes = GameObject.FindGameObjectsWithTag("Life").ToList();
        //money = 500;
        moneyText.text = money.ToString();
        Messenger<int>.Broadcast(GameEvent.MONEY_CHANGED, 500);
        popup.Close();
        lose.Close();
        win.Close();
    }
	
	// Update is called once per frame
	void Update () {
		if(isNoEnemies && isInsufficient)
        {
            win.Open();
        }
	}

    private void Awake()
    {
        //Messenger<int>.AddListener(GameEvent.ENEMY_DIED, OnEnemyDied);
        Messenger<int>.AddListener(GameEvent.ENEMY_PASSED, OnEnemyPassed);
        //Messenger<int>.AddListener(GameEvent.TOWER_PLACED, OnTowerPlaced);
        Messenger<int>.AddListener(GameEvent.MONEY_CHANGED, OnMoneyChanged);
        Messenger.AddListener(GameEvent.AI_INSUFFICIENT, OnAIInsufficient);
        Messenger.AddListener(GameEvent.NO_ENEMIES, OnNoEnemies);
    }

    private void OnDestroy()
    {
        //Messenger<int>.RemoveListener(GameEvent.ENEMY_DIED, OnEnemyDied);
        Messenger<int>.RemoveListener(GameEvent.ENEMY_PASSED, OnEnemyPassed);
        //Messenger<int>.RemoveListener(GameEvent.TOWER_PLACED, OnTowerPlaced);
        Messenger<int>.RemoveListener(GameEvent.MONEY_CHANGED, OnMoneyChanged);
        Messenger.RemoveListener(GameEvent.AI_INSUFFICIENT, OnAIInsufficient);
        Messenger.RemoveListener(GameEvent.NO_ENEMIES, OnNoEnemies);
    }

    public void OnExiting()
    {
        popup.Open();
    }


    private void OnMoneyChanged(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }

    private void OnEnemyPassed(int value)
    {
        //GameObject life = GameObject.FindGameObjectWithTag("Life");
        int repeats = (lifes.Count >= value) ? value : lifes.Count;
        for (int i = 0; i < repeats ; i++)
        {
            //Debug.Log(lifes[0].name);
            Destroy(lifes[0]);
            lifes.RemoveAt(0);
        }

        if (lifes.Count == 0)
        {
            
            lose.Open();
        }

    }

    private void OnAIInsufficient()
    {
        //Debug.Log("insufficient");
        isInsufficient = true;
    }

    private void OnNoEnemies()
    {
        //Debug.Log("no enemies");
        isNoEnemies = true;
    }
}
