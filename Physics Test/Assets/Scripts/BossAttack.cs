using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    public float speedRotate = 20.0f;
   
    void Update()
    {
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
