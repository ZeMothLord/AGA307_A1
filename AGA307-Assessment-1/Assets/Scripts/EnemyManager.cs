using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public Transform[] spawnPoints = new Transform[8];
    public GameObject[] enemyTypes = new GameObject[8];

    public List<GameObject> enemies = new List<GameObject>();
    int numIterations = 100;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //set the size of the array to 

        PrintNums();
        SpawnEnemy();
        SumFist10NaturalNumbers();
        SumNaturalNumber(420);
    }

    

    void PrintNums()
    {
        for (int i = 0; i < numIterations; i++)
        {
            print(i);
        }

    }


    void SpawnEnemy()
    {
        //Loop from 0 until the length of our spawnPoints array
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int rNum = UnityEngine.Random.Range(0, enemyTypes.Length);
            GameObject enemy = Instantiate(enemyTypes[rNum], spawnPoints[i].position, spawnPoints[i].rotation);
            //adds the newly created enemy to enemie list
            enemies.Add(enemy);
        }
        //print total number of enemy spawned
        print("Enemy Count: " + enemies.Count);
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
        for(int i = 1; i < targetNum + 1; i++)
            sum += i;

        Debug.Log(sum);



    }

    GameObject FindClosestEnemyToPlayer()
    {
        GameObject closestEnemy = null;
        float bestDistance = float.MaxValue;

        for(int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestEnemy = enemies[i];
            }
        }
        return closestEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemyToPlayer();
    }
}








    