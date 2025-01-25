using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject retryMenu;
     
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            pauseGame();
        }
    }


    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void retry()
    {
        Debug.Log("button clicked");
        retryMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
