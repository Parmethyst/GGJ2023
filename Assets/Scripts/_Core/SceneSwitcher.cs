using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("Menu (SINGKAT)");
    }
    public void ChangeToCredits()
    {
        SceneManager.LoadScene("CREDITT SCREEN");
    }
    public void ChangeToIntroGameplay()
    {
        SceneManager.LoadScene("_Intro");
    }
    public void ChangeToEnding()
    {
        SceneManager.LoadScene("_Ending");
    }
    public void ChangeToLvl1()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void ChangeToLvl3()
    {
        SceneManager.LoadScene("_Lv3");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
