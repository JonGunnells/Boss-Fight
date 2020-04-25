using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool projActive, seqOne, isDead;
    public float speed, startWaitTime;
    private float waitTime;
    public GameObject projectiles, sequenceOne;
    public Transform[] moveSpots;
    public RectTransform healthBarFull, hurtOne, hurtTwo, hurtThree, hurtFour;
    public PlayerController player;
    public int randomSpot, health;

    private void Start()
    {
        health = 100;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        CheckHealth();

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if(projActive == true)
        {
            projectiles.gameObject.SetActive(true);
        }
        else if(projActive == false)
        {
            projectiles.gameObject.SetActive(false);
        }

        if(seqOne == true)
        {
            sequenceOne.gameObject.SetActive(true);
        }
        else if(seqOne == false)
        {
            sequenceOne.gameObject.SetActive(false);
        }

    }


    public void CheckHealth()
    {
        if (health == 100)
        {
            healthBarFull.gameObject.SetActive(true);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(false);

        }
        else if (health == 75)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(true);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(false);
        }
        else if (health == 50)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(true);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(false);
        }
        else if (health == 25)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(true);
            hurtFour.gameObject.SetActive(false);
        }
        else if (health <= 0)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(true);
        }
    }


    public void GetHurt()
    {
        health -= 25;
        if(health <= 0)
        {
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetHurt();
        }
        else if(collision.tag == "Bullet")
        {
            GetHurt();
        }
    }

}
