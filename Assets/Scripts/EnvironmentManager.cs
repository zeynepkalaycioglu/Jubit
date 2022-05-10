using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject player;
    
    public List<GameObject> topWalls;
    public List<GameObject> bottomWalls;

    private float _widthOfSingleBlock = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTopWalls();
        CheckBottomWalls();
    }
    
    public void ResetWalls()
    {
        topWalls[0].transform.position = new Vector3(0f,0f,0f);
        topWalls[1].transform.position = new Vector3(0f,0f,90f);
        topWalls[2].transform.position = new Vector3(0f,0f,180f);
        bottomWalls[0].transform.position = new Vector3(0f,0f,0f);
        bottomWalls[1].transform.position = new Vector3(0f,0f,90f);
        bottomWalls[2].transform.position = new Vector3(0f,0f,180f);
    }
 

    private void CheckTopWalls()
    {
        if (topWalls[1].transform.position.z < player.transform.position.z)
        {
            ReplaceTopWalls();
        }

    }
    

    private void CheckBottomWalls()
    {
        if (bottomWalls[1].transform.position.z < player.transform.position.z)
        {
            ReplaceBottomWalls();
        }
    }

    private void ReplaceTopWalls()
    {
        GameObject myTempFirstWall = topWalls[0];
        myTempFirstWall.transform.position = topWalls[2].transform.position + new Vector3(0f,0f, _widthOfSingleBlock);
        topWalls.Add(myTempFirstWall);
        topWalls.RemoveAt(0);

    }
    private void ReplaceBottomWalls()
    {
        GameObject myTempFirstWall = bottomWalls[0];
        myTempFirstWall.transform.position = bottomWalls[2].transform.position + new Vector3(0f,0f, _widthOfSingleBlock);
        bottomWalls.Add(myTempFirstWall);
        bottomWalls.RemoveAt(0);

    }
}
