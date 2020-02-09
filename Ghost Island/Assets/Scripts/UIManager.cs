using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        SceneManager.LoadScene("PauseMenu");
    //    }
    //}

    public void GoToLevell1()
    {
        SceneManager.LoadScene("Game");
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //public void GoToPauseMenu()
    //{

    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        SceneManager.LoadScene("PauseMenu");
    //    }
    //}
}