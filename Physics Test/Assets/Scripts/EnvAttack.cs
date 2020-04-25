using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvAttack : MonoBehaviour
{
    public float speed = -0.5f;
    public int hole;

    public GameObject[] attacks;

    public float pos1 = -8.64f, pos2 = 1.48f, pos3 = -2.6f;

    private void Start()
    {
        
        
    }


    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if(transform.position.x > 9)
        {
            Obstacle();
            transform.position = new Vector3(pos1, pos2, pos3);
        }
    }

    public void Obstacle()
    {
        
        attacks[hole].gameObject.SetActive(true);
        hole = Random.Range(0, 8);
        attacks[hole].gameObject.SetActive(false);
        Debug.Log(hole);
        
    }


}
