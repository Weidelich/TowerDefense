using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPlace : MonoBehaviour, IPointerClickHandler {

    [SerializeField] private bool isTowerSell = false;
    private PlacingPopupController placingController;

    private bool isFilled = false;
    private Color color;

    // Use this for initialization
    void Start () {

        placingController = GameObject.Find("Placing popup").GetComponent<PlacingPopupController>();
        if (isTowerSell)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        color = gameObject.GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(eventData.position);
        if (isTowerSell)
        {
            placingController.Open();
            placingController.cellName = this.name;
            placingController.transform.Translate(new Vector3(eventData.position.x, eventData.position.y, 0) - placingController.transform.position);
        }
        else
        {
            placingController.Close();
        }

    }

    void Awake()
    {
        Messenger<Tower>.AddListener(this.name, OnTowerSelected);
    }

    private void OnDestroy()
    {
        Messenger<Tower>.RemoveListener(this.name, OnTowerSelected);
    }

    private void OnTowerSelected(Tower tower)
    {

        placingController.Close();

        tower.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);

        if (isTowerSell && isFilled == false)
        {
            Instantiate(tower, transform.parent);
            Messenger<int>.Broadcast(GameEvent.MONEY_CHANGED, -tower.cost);
            isFilled = true;
        }
    }


    private void OnMouseOver()
    {
        if (isTowerSell)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = color;
    }

}
