using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int damageAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //change the spheres colour to green
            other.GetComponent<MeshRenderer>().material.color = Color.red;
            //Destroy(other.gameObject, 1);

        }
        HealthManager healthManager = other.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.TakeDamage(damageAmount);
        }

    }

}
