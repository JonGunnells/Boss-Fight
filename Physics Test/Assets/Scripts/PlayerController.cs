using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;

    public int health;

    public bool isDead;

    public float speed, jumpVelocity;

    public GameObject bullet;

    public BossController boss;

    public RectTransform healthBarFull, hurtOne, hurtTwo, hurtThree, hurtFour;

    

    void Start()
    {
        isDead = false;
        health = 100;
        jumpVelocity = 4;
        speed = 10;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Debug.Log("PLAYER HEALTH: " + health + " BOSS HEALTH: " + boss.health);
        PlayerMovement();
        Attack();
        CheckHealth();
    }

   public void GetHurt()
    {
        health -= 25;
        if(health <= 0)
        {
            isDead = true;
        }
    }

    public void PlayerMovement()
    {
       speed = Input.GetAxisRaw("Horizontal") * 10 * Time.deltaTime;
       transform.Translate(speed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
       
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        }
    }

    public void CheckHealth()
    {
        if(health == 100)
        {
            healthBarFull.gameObject.SetActive(true);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(false);

        }
        else if(health == 75)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(true);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(false);
        }
        else if(health == 50)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(true);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(false);
        }
        else if(health == 25)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(true);
            hurtFour.gameObject.SetActive(false);
        }
        else if(health <= 0)
        {
            healthBarFull.gameObject.SetActive(false);
            hurtOne.gameObject.SetActive(false);
            hurtTwo.gameObject.SetActive(false);
            hurtThree.gameObject.SetActive(false);
            hurtFour.gameObject.SetActive(true);
        }
    }

}
