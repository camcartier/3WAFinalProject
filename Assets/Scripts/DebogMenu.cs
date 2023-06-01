using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebogMenu : MonoBehaviour
{
    [SerializeField] GameObject DebogPanel;
    [SerializeField] GameObject PausePanel;

    public void EnableDebog()
    {
        DebogPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void DisableDebog()
    {
        DebogPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("EndingScene");
    }

    public void LoadTest()
    {
        SceneManager.LoadScene("TestScene");
    }
}
