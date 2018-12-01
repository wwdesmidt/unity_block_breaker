using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current scene: " + currentSceneIndex + ", loading next scene");
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void loadFirstScene()
    {

        FindObjectOfType<GameStatus>().reset();

        SceneManager.LoadScene(0);

    }

    public void quitGame()
    {
        Application.Quit();
    }
}
