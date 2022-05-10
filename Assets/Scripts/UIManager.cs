using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject waitingPanel;
    public GameObject gameOverPanel;
    
    public Text scoreText;

    private int _currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStarted()
    {
        waitingPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scoreText.text = _currentScore.ToString();
    }
    public void GameEnded()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void ObstaclePassed(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}
