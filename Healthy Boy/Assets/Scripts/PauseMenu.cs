using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CotinueGame();
        }
    }
    public void CotinueGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }
}
