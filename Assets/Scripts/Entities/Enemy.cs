using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float health = 1;
    [SerializeField] private int bounty;
    public int danger;

    private Transform waypoints;
    private Transform waypoint;
    private int waypointIndex= -1;



	// Use this for initialization
	void Start () {
        waypoints = GameObject.Find("WayPoints").transform;
        NextWayPoint();
	}
	
	// Update is called once per frame
	void Update () {
        float _speed = Time.deltaTime * speed;
        Vector3 dir = waypoint.transform.position - transform.position;
        dir.y = 0;
        transform.Translate(dir.normalized * _speed);
        if (dir.magnitude <= _speed)
        {
            NextWayPoint();
        }
	}

    public void Hurt(int damage)
    {
        Debug.Log("damage: " + damage + "\n hp: " + health);
        health -= damage;
        if (health <= 0)
        {
            Messenger<int>.Broadcast(GameEvent.MONEY_CHANGED,bounty);
            Destroy(this.gameObject);
        }
    }

    private void NextWayPoint()
    {
        waypointIndex++;

        if (waypointIndex >= waypoints.childCount)
        {
            Messenger<int>.Broadcast(GameEvent.ENEMY_PASSED,danger);
            Destroy(gameObject);
            return;
        }
        waypoint = waypoints.GetChild(waypointIndex);
    }
}
