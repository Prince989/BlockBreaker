using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockBreakerUIController : MonoBehaviour
{
    //UI
    public GameObject ResultPanel;
    public GameObject ResultScoreUI;
    public GameObject LosePanel;
    public Sprite LoseSprite;
    public GameObject[] Stars;

    //Buttons
    public GameObject restartBtn;
    public GameObject homeBtn;

    public int score;
    public string nextScene;

    public int maxBricksCount;
    public int zarib = 3;

    public bool EndGame = false;

    bool isMuteSound = false;
    bool isMuteMusic = false;

    void Start()
    {
        restartBtn.GetComponent<Button>().onClick.AddListener(RestartGame);
        homeBtn.GetComponent<Button>().onClick.AddListener(Quit);
    }
    void Quit()
    {
        Application.Quit();
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ShowGameComplete(int score)
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Scoreee : " + score);

        int starCount = ((score * 100) / maxBricksCount);
        Debug.Log("Here is the thing : " + starCount + ",," + maxBricksCount + ",," + score);
        if (starCount < 30)
        {
            LosePanel.GetComponent<Image>().sprite = LoseSprite;
        }

        ResultPanel.SetActive(true);


        if (starCount == 100)
        {
            starCount = 3;
        }
        else if (starCount >= 60)
        {
            starCount = 2;
        }
        else if (starCount < 60 && starCount >= 30)
        {
            starCount = 1;
        }
        else if (starCount < 30)
        {
            starCount = 0;
        }
        
        score = ((int)(score * zarib));

        ResultScoreUI.GetComponent<Text>().text = score.ToString();
        

        foreach (GameObject star in Stars)
        {
            star.SetActive(false);
        }
        
        for (int i = 0; i < starCount; i++)
        {
            Stars[i].SetActive(true);
        }
    }
    public void GameComplete(int score)
    {
        StartCoroutine(ShowGameComplete(score));
    }
}
