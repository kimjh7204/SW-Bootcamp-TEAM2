using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public string sceneName = "InGameScene";

    public void ClickRetry()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
