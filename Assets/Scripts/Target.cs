using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 60f;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Damage(float damageAmount)
    {
        health = health - damageAmount;

        if(health <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
