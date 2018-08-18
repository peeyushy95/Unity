using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [SerializeField] int pointsPerBlockDestroyed = 50;
    [SerializeField] bool isAutoPlayEnabled = false;

    [Range(.1f, 10f)][SerializeField] float gameSpeed = 1f;

    [SerializeField] TextMeshProUGUI userScore;
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int instancesCount = FindObjectsOfType<GameStatus>().Length;
        if(instancesCount > 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        userScore.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}

    public  void addToScore(){
        currentScore += pointsPerBlockDestroyed;
        userScore.text = currentScore.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}

