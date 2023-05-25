using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerStartMenu : MonoBehaviour
{
    #region Sound
    [SerializeField] AudioSource _menuBackgroundMusic;
    #endregion

    #region Unlocks
    public bool _hasFire;
    public bool _hasIce;
    public bool _hasBoots;
    public bool _hasCape;
    public bool _hasSword;
    #endregion

    #region PlayerInfo
    [SerializeField] PlayerData PlayerData;
    #endregion

    #region SAVE&LOAD
    private PlayerCurrentInfo playerCurrentInfo;
    #endregion

    #region Menus
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject NewGamePanel;
    [SerializeField] GameObject EscapePanel;
    [SerializeField] Animator TextZoneAnimator;
    [SerializeField] Animator TitlePanelAnimator;
    [SerializeField] Animator NewGamePanelAnimator;
    [SerializeField] Animator EscapePanelAnimator;
    private bool _newGameMenuOn;
    private float LerpDuration = 180f;
    private float timeElapsed;
    //private bool _isOverScene;
    #endregion

    void Awake()
    {
        playerCurrentInfo = FindObjectOfType<PlayerCurrentInfo>();
    }


    void Start()
    {
        _menuBackgroundMusic.Play();
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

        if (_newGameMenuOn)
        {
            if (timeElapsed < LerpDuration)
            {
                _menuBackgroundMusic.volume = Mathf.Lerp(_menuBackgroundMusic.volume, 0.15f, timeElapsed/LerpDuration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                _menuBackgroundMusic.volume = 0.15f;
            }
            
        }
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
        _newGameMenuOn = true;


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


    //save management
    #region SAVE&LOAD

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerCurrentInfo);
    }

    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();

        playerCurrentInfo.currentSceneIndex = data.sceneIndex;
        playerCurrentInfo.playerName = data.playerName;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

    }
    #endregion
}
