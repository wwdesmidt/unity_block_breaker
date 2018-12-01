using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int playerScore = 0;
    [SerializeField] int pointsPerBlock = 1;
    [SerializeField] Text scoreTextBox;
    [SerializeField] bool isAutoEnabled;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        scoreTextBox.text = playerScore.ToString();
    }

    // Use this for initialization
    public void addScore()
    {
        playerScore += pointsPerBlock;
        scoreTextBox.text = playerScore.ToString();
    }

    public void reset()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = gameSpeed;	
	}

    public bool isAutoPlayEnabled()
    {
        return isAutoEnabled;
    }
}
