using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public GameDifficulty difficulty;

    public int scoreMultiplyer = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        difficulty = GameDifficulty.Easy;
    }

    // Update is called once per frame
    void Update()
    {
        
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
