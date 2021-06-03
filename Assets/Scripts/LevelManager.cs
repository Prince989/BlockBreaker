using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject UIController;

    public void LoadLevel(string name){

        Debug.Log("Level load requested for: " + name);
		Brick.breakableCount = 0;
        UIController.GetComponent<BlockBreakerUIController>().GameComplete(Brick.bricksDestroyed);
       //SceneManager.LoadScene(name);
    }

    public void QuitRequest(){
        Debug.Log("I want to Quit");
        Application.Quit();
    }

    public void BackRequest()
    {
        Debug.Log("I want to go back");
    }

    public void LoadNextLevel()
    {
		Brick.breakableCount = 0;
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
