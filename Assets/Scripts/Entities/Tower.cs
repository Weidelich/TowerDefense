using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] private float range = 2f;
    [SerializeField] private GameObject bulletPrefab;
    public int cost;
    private GameObject bullet;
    [SerializeField] private float timeShoot;
    private Enemy enemy;
    private Transform towerHead;
    private float timer;
	// Use this for initialization
	void Start () {
        towerHead = transform.Find("Head");
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy == null)
        {
            FindEnemy();
        } else
        {
            //Debug.Log(towerHead);
            towerHead.LookAt(enemy.transform);
            //towerHead.rotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
            //Transform gun = towerHead.Find("Gun");
            Shoot();
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance > range)
            {
                enemy = null;
            }
            //var rotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
        }
    }

    private void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Instantiate(bullet, transform.parent);
            bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = towerHead.TransformPoint(Vector3.forward * 1.5f);
            bullet.transform.rotation = towerHead.rotation;

            
            timer = timeShoot;
        }
    }

    private void FindEnemy()
    {
        var enemies = GameObject.FindObjectsOfType<Enemy>();
        if (enemies.Length == 0)
        {
            Messenger.Broadcast(GameEvent.NO_ENEMIES);
        }
        float min = range;
        Enemy minEnemy = null;
        //Debug.Log(transform.position.x + " " + transform.position.z);
        foreach(var e in enemies)
        {
            float distance = Vector3.Distance(e.transform.position, transform.position);
            if (distance <= min)
            {
                min = distance;
                minEnemy = e;
            }

            //Debug.Log("Enemy" + enemy.transform.position.x + " " + enemy.transform.position.z);
        }
        enemy = minEnemy;
    }


}
