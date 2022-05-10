using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject singleObstaclePrefab;
    private int _initialObstacleCount = 5;
    private float _obstaclesDistance = 10f;

    private float _maxObstacleYPos = -9f;
    private float _minObstacleYPos = -19f;
    
    public GameObject finalObstacle;
    public GameObject initialObstacle;

    private float _finalObstacleZPos;

    public List<GameObject> runTimeObstacles;

    private Coroutine _checkPlayerPositionCoroutine;

    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SpawnInitialObstacles()
    {
        isGameOver = false;
       runTimeObstacles = new List<GameObject>();
        for (int i = 0; i < _initialObstacleCount; i++)
        {
            SpawnNewObstacle();
        }
        _checkPlayerPositionCoroutine = StartCoroutine(CheckIfPlayerCloseToFinalObstacle());
    }
    
    public IEnumerator CheckIfPlayerCloseToFinalObstacle()
    {
        while (isGameOver == false)
        {
            yield return new WaitForSeconds(0.5f);
            if (GameManager.Instance.playerController.transform.position.z > _finalObstacleZPos - 20)
            {
                SpawnNewObstacle();   
            }
            
        }
        
    }
    
    
    
    

    private void SpawnNewObstacle()
    {
        if (finalObstacle)
        {
            _finalObstacleZPos = finalObstacle.transform.position.z;
            finalObstacle = Instantiate(singleObstaclePrefab, new Vector3(0f, UnityEngine.Random.Range(_maxObstacleYPos,_minObstacleYPos), _finalObstacleZPos + _obstaclesDistance),
                Quaternion.identity, transform);
            runTimeObstacles.Add(finalObstacle);
        }
       
    }

    public void ObstaclePassed(GameObject scoreDetector)
    {
       // scoreDetector.gameObject.SetActive(false);
    }

    public void DestroyRuntimeObstacles()
    {
        isGameOver = true;
        StopCoroutine(_checkPlayerPositionCoroutine);
        finalObstacle = initialObstacle;
        _finalObstacleZPos = initialObstacle.transform.position.z;
        for (int i = runTimeObstacles.Count - 1; i>=0; i--)
        {
            Destroy(runTimeObstacles[i].gameObject);
            runTimeObstacles.RemoveAt(i);
        }
    }

    public void GameOver()
    {
        //Destroy(GameObject.);
    }
}
