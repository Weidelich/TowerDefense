using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float speed = 10f;
    public int damage = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        float distance = 0.1f;
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;//Переменная для приёма результата попадания луча

        //Стреляем лучём вперёд:
        if (Physics.Raycast(ray, out hit, distance))
        {
            //Теперь мы можем узнать:

            //hit.distance - дистанция до обьекта, в который попал луч (пуля)

            //hit.collider - сам объект в который мы попали

            //hit.collider.name - имя  объекта, в который мы попали
            
            var enemy = hit.collider.GetComponent<Enemy>();
            if(enemy == null) return;
            enemy.Hurt(damage); //уничтожить объект в который мы попали

            //Destroy(gameObject);

            //Destroy (hit.collider.gameObject, 5); - уничтожить объект вкоторый мы попали, через 5 секунд после попадания

            //hit.collider.animation.Play(); - проиграть анимацию "поражения" объекта

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
       Destroy(gameObject);
    }
}
