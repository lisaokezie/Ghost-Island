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

    public void GoToLevell1()
    {
        SceneManager.LoadScene("02_Game");
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }

    public void QuitGame()
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