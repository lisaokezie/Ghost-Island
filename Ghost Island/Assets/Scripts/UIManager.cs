using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static void GoToLevell1()
    {
        SceneManager.LoadScene("02_Game");
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("02_Game");
        Time.timeScale = 1;
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}