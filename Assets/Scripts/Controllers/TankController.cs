using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class TankController : MonoBehaviour {
        public float MoveSpeed { get; set; }

        public List<Vector2> Route { get; set; }
        private float distance;
        private float lerpTime;
        private float currentLerpTime;
        private float movedDistanceInPercent;
        private Vector2 startPos;
        private Vector2 endPos;
        private int currentCheckPoint;

        // Use this for initialization
        void Start ()
        {
            MoveSpeed = 30f;
            Route = new List<Vector2>()
            {
                new Vector2(-150, 0),
                new Vector2(-50, 0),
                new Vector2(-50, 90),
                new Vector2(60, 90),
                new Vector2(60, -30),
                new Vector2(100, -30),
                new Vector2(100, 45),
                new Vector2(150, 45)
            };
            startPos = Route[0];
            endPos = Route[1];
            currentCheckPoint = 1;
            distance = GetDistance();
            lerpTime = GetLerpTime();
            currentLerpTime = 0;
            //Rotate();
        }

        private float GetLerpTime()
        {
            return distance / MoveSpeed;
        }

        private float GetDistance()
        {
            return Mathf.Sqrt(Mathf.Pow(endPos.x - startPos.x, 2) + Mathf.Pow(endPos.y - startPos.y, 2));
        }

        // Update is called once per frame
        void Update ()
        {
            Move();
            //Rotate();
        }

        private void Move()
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                startPos = endPos;
                currentCheckPoint++;
                if (currentCheckPoint < Route.Count)
                {
                    endPos = Route[currentCheckPoint];
                    Rotate();
                    distance = GetDistance();
                    lerpTime = GetLerpTime();
                    currentLerpTime = 0;
                }
                else return;
            }
            movedDistanceInPercent = currentLerpTime / lerpTime;
            transform.position = Vector2.Lerp(startPos, endPos, movedDistanceInPercent);
        }

        private void Rotate()
        {
            if (currentCheckPoint >= Route.Count) return;
            float angle = 90;
            float eps = 0.01f;
            if (Math.Abs(startPos.x - endPos.x) < eps)
                angle = startPos.y < endPos.y ? angle : -angle;
            if (Math.Abs(startPos.y - endPos.y) < eps)
                angle = -180;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
            //transform.Rotate(0, 0, angle);
            print(angle);
        }
    }
}
