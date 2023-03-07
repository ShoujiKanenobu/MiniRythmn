using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Placement is dealt with by the enemy spanwer

    public float speed;
    public GORuntimeSet enemySet;

    public void Awake()
    {
        enemySet.Add(this.gameObject);
    }

    public void OnDestroy()
    {
        enemySet.Remove(this.gameObject);
    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
