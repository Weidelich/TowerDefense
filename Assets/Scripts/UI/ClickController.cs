using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerClickHandler {
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        try
        {
            GameObject.Find("Placing popup").GetComponent<PlacingPopupController>().Close();
        }
        catch (Exception e)
        {
            //print(e.Message);
        }
    }
}
