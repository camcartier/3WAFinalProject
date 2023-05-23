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

    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
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
