using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyTypes myType;

    public int health;

    float moveDistance = 500;

    void Start()
    {
        SetUp();
        StartCoroutine(Move());
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());

        }   
    }
    */
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
                health = 100; 
                break;
            case EnemyTypes.TwoHanded: 
                health = 200; 
                break;
            case EnemyTypes.Archer:
                health = 50; 
                break;
        }
    }



}
