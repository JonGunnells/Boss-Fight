using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public PlayerController player;



    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetHurt();
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
