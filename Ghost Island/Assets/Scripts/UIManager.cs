using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    void Start()
    {
    }
    //public GameObject manual;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        SceneManager.LoadScene("PauseMenu");
    //    }
    //}

    public static void GoToLevell1()
    {
        SceneManager.LoadScene("02_Game");
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("02_Game");
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

    //public void Manual()
    //{
    //    manual.SetActive(true);
    //}

    //public void GoToPauseMenu()
    //{

    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        SceneManager.LoadScene("PauseMenu");
    //    }
    //}
}