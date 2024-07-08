using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{



    public GameState gameState;
    public GameDifficulty difficulty;
    public EnemyManager enemyManager;

    public int scoreMultiplyer = 1;

    static public int score = 0;
    static public int timeRemaining = 60;

    public GameObject scoretextBox;
    public GameObject timetextBox;


    public GameObject pauseMenuUI;

    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        //difficulty = GameDifficulty.Easy;
        GameEvents.EnemyHit += EnemyHit;
        StartCoroutine(timer());
        
        Time.timeScale = 0f;

        
        Cursor.lockState = CursorLockMode.None;
        

    }


    public void clickEasy()
    {
        difficulty = GameDifficulty.Easy;
        ResumeGame();
    }
    public void clickMedium() 
    {
        difficulty = GameDifficulty.Medium;
        ResumeGame();
    }

    public void clickHard() 
    {
        difficulty = GameDifficulty.Hard;
        ResumeGame();
    }

    private void OnDestroy()
    {
        GameEvents.EnemyHit -= EnemyHit;
    }

    // Update is called once per frame
    void Update()
    {
        scoretextBox.GetComponent<Text>().text = score.ToString();
        timetextBox.GetComponent<Text>().text = "Time" + timeRemaining.ToString();

        if (Input.GetKeyDown(KeyCode.Escape)) // You can change the key to pause/unpause as needed
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd * scoreMultiplyer;
    }

    void EnemyHit(Enemy e)
    {
        AddScore(10);
    }

    public IEnumerator timer() 
    { 
        yield return new WaitForSeconds(1);
        timeRemaining -= 1;
        StartCoroutine(timer());
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true;

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void SizeSetUp()
    {
        if (difficulty == GameDifficulty.Easy)
        {
            
        }

        else if (difficulty == GameDifficulty.Medium)
        {

        }
        else if (difficulty == GameDifficulty.Hard)
        {

        }
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
