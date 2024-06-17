using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;

    public int damageAmount = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    //shouldve done on collision enter

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
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
