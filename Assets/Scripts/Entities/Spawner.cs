using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private Enemy[] spawnerObjects;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private int resources;
    private float timer = 0;
    private Enemy currentEnemy;
	// Use this for initialization
	void Start () {
        //spawnerObjects[0].transform.position = transform.position;
        //spawnerObjects[1].transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;
        if (timer <= 0 && resources > 0)
        {
            int index = FindEnemy();
            //Debug.Log(index);
            if (index != -1)
            {
                resources -= spawnerObjects[index].danger;
                Instantiate(spawnerObjects[index], transform.parent);
                timer = spawnTime;
                currentEnemy = null;
            }
        }
        else
        {
            //broadcast only one time
            if (resources <= 0 && resources > -100)
            {
                Messenger.Broadcast(GameEvent.AI_INSUFFICIENT);
                resources = -100;
            }
        }
	}

    private int FindEnemy()
    {
        int max = 0;
        int enemyIndex = -1;
        for(int i=0;i<spawnerObjects.Length;i++)
        {
            //Debug.Log("danger: "+spawnerObjects[i].danger +"\n resources: " + resources + "\n max: " + max);
            if (spawnerObjects[i].danger <= resources && spawnerObjects[i].danger > max)
            {
                enemyIndex = i;
                max = spawnerObjects[i].danger;
            }
        }
        return enemyIndex;

    }
}
