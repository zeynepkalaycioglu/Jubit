using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public UIManager uiManager;
    public ObstacleManager obstacleManager;
    public EnvironmentManager environmentManager;
    public SoundManager soundManager;
    
    public int score = 0 ;

    public bool isGameStarted = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }
        SoundManager.Instance.PlayBgMusic(SoundManager.BgMusicTypes.MainBgMusic);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGameStarted)
            {
               StartGame();
            }
        }
    }

    public void StartGame()
    {
        score = 0;
        isGameStarted = true;
        playerController.StartGame();
        uiManager.GameStarted();
        obstacleManager.SpawnInitialObstacles();
    }

    public void GameOver()
    {
        environmentManager.ResetWalls();
        isGameStarted = false;
        playerController.GameEnded();
        uiManager.GameEnded();
        obstacleManager.DestroyRuntimeObstacles();
       
    }
    
    public void ObstaclePassed(GameObject scoreDetector)
    {
        score++;
        uiManager.ObstaclePassed(score);
        obstacleManager.ObstaclePassed(scoreDetector);
    }
}
