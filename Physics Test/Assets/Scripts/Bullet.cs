using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    private Vector3 moveDirection;




    void Start()
    {
        speed = 30.0f;
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
    }

   
    void Update()
    {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;

        if(transform.position.y < -10 || transform.position.y > 10 || transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            Destroy(this.gameObject);
        }
    }
}
