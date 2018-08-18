using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomAddVelocity = 0.2f;

    Vector2 paddleToBallVector;
    Boolean hasStarted = false;

    // cache the reference
    AudioSource audioSource;
    Rigidbody2D ballRigidbody2D;


	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        ballRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0)){
            hasStarted = true;
            ballRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddleVec = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddleVec + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweakVelocity = new Vector2(UnityEngine.Random.Range(0, randomAddVelocity), UnityEngine.Random.Range(0, randomAddVelocity));
        if (hasStarted)
        {
            AudioClip audio = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(audio);
            ballRigidbody2D.velocity += tweakVelocity;
        }
    }
}
