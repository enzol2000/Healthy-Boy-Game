using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mPlayButton;
    public GameObject mHowToPlayButton;
    public GameObject mExitButton;
    public GameObject mHowToPlayExplanation;



    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ShowHowToPlay()
    {
        mHowToPlayExplanation.SetActive(true);
        mHowToPlayButton.SetActive(false);
        mPlayButton.SetActive(false);
        mExitButton.SetActive(false);
    }
    public void HideHowToPlay()
    {
        mHowToPlayExplanation.SetActive(false);

        mHowToPlayButton.SetActive(true);
        mPlayButton.SetActive(true);
        mExitButton.SetActive(true);
    }
}
