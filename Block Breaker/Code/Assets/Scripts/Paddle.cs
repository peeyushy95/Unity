using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cache reference
    GameStatus gameStatus;
    Ball ball;


	// Use this for initialization
	void Start () {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
    void Update () {
        Vector2 paddleUpdatePos = new Vector2(transform.position.x, transform.position.y);
        paddleUpdatePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddleUpdatePos;
	}

    private float GetXPos(){
        if(gameStatus.IsAutoPlayEnabled()){
            return ball.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
