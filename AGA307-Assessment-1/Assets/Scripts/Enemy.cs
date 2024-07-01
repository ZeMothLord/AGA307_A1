using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyTypes myType;

    public int health = 3;

    float moveDistance = 500;

    void Start()
    {
        SetUp();
        StartCoroutine(Move());
    }

    private void Update()
    {
        //temp remove later
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            Hit();
        }
    }
    
    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        //rotate object around
        transform.Rotate(Vector3.up * 180);
        //wait 3 secs
        yield return new WaitForSeconds(3);
        
        StartCoroutine(Move());
        /*yield return new WaitForSeconds(3);
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime);
            yield return null;
        }
        */
        
        

    }

    void SetUp() 
    {
        switch(myType) 
        {
            case EnemyTypes.OneHanded:
                health = 5; 
                break;
            case EnemyTypes.TwoHanded: 
                health = 10; 
                break;
            case EnemyTypes.Archer:
                health = 1; 
                break;
        }
    }

    void Hit()
    {
        GameEvents.OnEnemyHit(this);
        health--;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        GameEvents.OnEnemyDie(this);
        StopAllCoroutines();
        Destroy(this.gameObject);
        
    }
}
