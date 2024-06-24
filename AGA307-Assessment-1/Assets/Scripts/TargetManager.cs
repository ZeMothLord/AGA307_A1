using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;


public class TargetManager : MonoBehaviour
{
    public Transform[] targetspawnPoints = new Transform[3];
    public GameObject[] targetTypes = new GameObject[3];

    public List<GameObject> targets = new List<GameObject>();
    int numIterations = 100;

    public GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
       
        PrintNums();
    }

void SpawnTarget()
    {
        //Loop from 0 until the length of our spawnPoints array
        for (int i = 0; i < targetspawnPoints.Length; i++)
        {
            int rNum = Random.Range(0, targetTypes.Length);
            GameObject target = Instantiate(targetTypes[rNum], targetspawnPoints[i].position, targetspawnPoints[i].rotation);
            //adds the newly created enemy to enemie list
            targets.Add(target);
        }
        //print total number of enemy spawned
        print("Target Count: " + targets.Count);
    }

    void PrintNums()
    {
        for (int i = 0; i < numIterations; i++)
        {
            print(i);
        }

    }


    void SumFist10NaturalNumbers()
    {
        int sum = 0;
        for (int i = 1; i < 11; i++)
            sum += i;

        Debug.Log(sum);
    }

    void SumNaturalNumber(int targetNum)
    {
        int sum = 0;
        for (int i = 1; i < targetNum + 1; i++)
            sum += i;

        Debug.Log(sum);



    }

    /*
    GameObject FindClosestEnemyToPlayer()
    {
        GameObject closestTarget = null;
        float bestDistance = float.MaxValue;

        for (int i = 0; i < targets.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, targets[i].transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestTarget = targets[i];
            }
        }
        return closestTarget;
    }
    */

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnTarget();
        }
        //FindClosestEnemyToPlayer();
    }
    
}
