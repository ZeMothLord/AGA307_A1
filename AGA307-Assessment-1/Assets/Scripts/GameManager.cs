using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{



    public GameState gameState;
    public GameDifficulty difficulty;
    public EnemyManager enemyManager;

    public int scoreMultiplyer = 1;

    public int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        difficulty = GameDifficulty.Easy;
        GameEvents.EnemyHit += EnemyHit;

    }

    private void OnDestroy()
    {
        GameEvents.EnemyHit -= EnemyHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd * scoreMultiplyer;
    }

    void EnemyHit(Enemy e)
    {
        AddScore(10);
    }




    void SetUp() 
    {
        switch(difficulty) 
        {
            case GameDifficulty.Easy:
                scoreMultiplyer = 1; 
                break;
            case GameDifficulty.Medium:
                scoreMultiplyer = 2; 
                break;
            case GameDifficulty.Hard:
                scoreMultiplyer = 3;
                break;
        }
    }


}
