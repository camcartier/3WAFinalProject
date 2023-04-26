using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Sound
    [SerializeField] AudioSource _menuBackgroundMusic;
    [SerializeField] AudioSource _meadowBackgroundMusic;
    #endregion

    #region Pause
    public bool _gameIsPaused;
    public bool _gameIsPlaying;
    [SerializeField] GameObject PausePanel;
    #endregion

    #region Respawn
    [SerializeField] GameObject RespawnPoint;
    #endregion

    #region Unlocks
    public bool _hasFire;
    public bool _hasIce;
    public bool _hasBoots;
    public bool _hasCape;
    public bool _hasSword;
    #endregion

    #region Sliders
    [SerializeField] ManaSlider ManaSlider;
    [SerializeField] HealthSlider HealthSlider;
    #endregion

    #region Health&Mana
    private int _storedMana;
    private int _storedHealth;
    #endregion

    #region Spells
    public bool _isUsingSpell;
    public bool _isPlayingFX;
    #endregion

    #region FXs
    private GameObject ManaParticles;
    #endregion

    #region PlayerInfo
    [SerializeField] GameObject Player;
    [SerializeField] PlayerData PlayerData;
    #endregion

    void Awake()
    {
        PlayerData._currentHealth = PlayerData._maxHealth;
        PlayerData._currentMana = PlayerData._maxMana;
    }


    // Start is called before the first frame update
    void Start()
    {
        ManaParticles = GameObject.Find("UsingMana");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) && !_gameIsPaused)
        {
            PauseGame();
            //_gameIsPaused = true;
        }
        /*
        else if (Input.GetKeyDown(KeyCode.Escape) && _gameIsPaused)
        {
            ResumeGame();
            //_gameIsPaused = false;
        }*/

        if (_isUsingSpell && !_isPlayingFX)
        {
            ManaParticles.SetActive(true);
            _isPlayingFX = true;
        }

        if (_isUsingSpell && PlayerData._currentMana > 0)
        {
            PlayerData._currentMana -= 0.1f;
        }
        if ( PlayerData._currentMana <= 0 || !_isUsingSpell)
        {
            ManaParticles.SetActive(false);
        }
        
        if (!_isUsingSpell && PlayerData._currentMana < PlayerData._maxMana)
        {
            ManaParticles.SetActive(false);
            PlayerData._currentMana += 0.1f;
            Debug.Log(PlayerData._currentMana);
        }



        /*
        if ()
        {

        }*/

        if (PlayerData._currentHealth <= 0)
        {
            DeathRespawn();
        }

    }


    public void DeathRespawn()
    {
        CharacterController CharaControls = Player.GetComponent<CharacterController>();
        CharaControls.enabled = false;
        
        Vector3 RespawnPos = new Vector3(RespawnPoint.transform.position.x, RespawnPoint.transform.position.y, RespawnPoint.transform.position.z);
        Player.transform.position = RespawnPos;

        CharaControls.enabled = true;
    }



    public void LevelUp()
    {
        PlayerData._maxMana += 10;
        PlayerData._maxHealth += 2;
        ManaSlider.SetMaxMana(PlayerData._maxMana);
        HealthSlider.SetMaxHealth(PlayerData._maxHealth);
    }



    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;

    }
    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;

    }
    public void QuitGame()
    {
        Application.Quit();
    }




}

