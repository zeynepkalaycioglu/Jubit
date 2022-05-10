using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;

    //public Collider playerCollider;
    private Vector3 _initialPos;

    private float JumpForce = 7f;
    private float movePower = 5f;

    // Start is called before the first frame update
    void Start()
    {

        _initialPos = transform.position;
        Time.timeScale = 2f;
        if (playerRb == null)
        {
            playerRb = GetComponentInChildren<Rigidbody>();
        }

        playerRb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            transform.position += new Vector3(0f, 0f, 1f * Time.deltaTime * movePower);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

    }

    private void Jump()
    {
        playerRb.velocity = new Vector3(0f, JumpForce, 0f);
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Jump);
    }

    public void StartGame()
    {
        transform.position = _initialPos;
        playerRb.useGravity = true;
        playerRb.isKinematic = false;
    }

    public void GameEnded()
    {
        playerRb.isKinematic = true;
        playerRb.velocity = new Vector3(0f, 0f, 0f);
        playerRb.useGravity = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameManager.Instance.GameOver();
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Crash);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("scoreDetector"))
        {
            //collision.GetComponent<BoxCollider>().enabled = false;
            GameManager.Instance.ObstaclePassed(collision.gameObject);
        }
    }
}
