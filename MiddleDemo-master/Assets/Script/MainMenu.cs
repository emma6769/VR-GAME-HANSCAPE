using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string loadingScene;
    public string HelpScene;

    public void LoadStart() {
        SceneManager.LoadScene(loadingScene);
    }

    public void IsHelp()
    {
        print("도움말!");
        SceneManager.LoadScene(HelpScene);
    }

    public void IsExit() {
        print("종료!");
        Application.Quit();
    }
    
}
