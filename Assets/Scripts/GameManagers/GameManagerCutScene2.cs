using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerCutScene2
    : MonoBehaviour
{
    #region Sound
    [SerializeField] AudioSource _mouseDialogueMusic;
    #endregion


    #region Menus
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject NewGamePanel;
    [SerializeField] GameObject EscapePanel;
    [SerializeField] Animator TextZoneAnimator;
    [SerializeField] Animator TitlePanelAnimator;
    [SerializeField] Animator NewGamePanelAnimator;
    [SerializeField] Animator EscapePanelAnimator;
    #endregion

    void Awake()
    {

    }


    void Start()
    {
        //_menuBackgroundMusic.Play();
    }


    void Update()
    {
        /*
        if (_isOverScene)
        {
            TextZoneAnimator.SetBool("fade", true);
        }
        else { TextZoneAnimator.SetBool("fade", false); }
        */

        /*
        if (_newGameMenuOn)
        {
            if (timeElapsed < LerpDuration)
            {
                _menuBackgroundMusic.volume = Mathf.Lerp(_menuBackgroundMusic.volume, 0.15f, timeElapsed / LerpDuration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                _menuBackgroundMusic.volume = 0.15f;
            }

        }
        */
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HidePreviousPanel()
    {
        //MainPanel.SetActive(false);
        NewGamePanel.SetActive(true);
        EscapePanel.SetActive(true);
        //_newGameMenuOn = true;


        TitlePanelAnimator.SetBool("fade", true);
        NewGamePanelAnimator.SetBool("fade", true);
        TextZoneAnimator.SetBool("fadein", true);
        EscapePanelAnimator.SetBool("fadein", true);
    }

    public void SetTXTAnimator()
    {
        TextZoneAnimator.SetBool("fade", true);
        EscapePanelAnimator.SetBool("fadeout", true);
    }
    public void WrapCoroutineLoadNext()
    {
        StartCoroutine(LoadNextSceneAfterTime());
    }

    public IEnumerator LoadNextSceneAfterTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}