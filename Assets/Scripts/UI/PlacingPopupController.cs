using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacingPopupController : MonoBehaviour {

    [SerializeField] private Tower[] towers;
    [SerializeField] private Button[] buttons;
    private int money = 0;
    public string cellName = "";
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

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
        for(int i = 0; i < towers.Length; i++)
        {
            if (money < towers[i].cost)
            {
                buttons[i].interactable = false;
                buttons[i].GetComponentInChildren<Text>().color = Color.red;
            } else
            {
                buttons[i].interactable = true;
                buttons[i].GetComponentInChildren<Text>().color = Color.black;
            }
        }
        
    }

    public void Tower1()
    {
        Messenger<Tower>.Broadcast(cellName, towers[0]);
    }

    public void Tower2()
    {
        Messenger<Tower>.Broadcast(cellName, towers[1]);
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

    }
}
