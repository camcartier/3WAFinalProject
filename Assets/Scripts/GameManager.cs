using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Sound
    [SerializeField] AudioSource meadowBackgroundMusic;
    [SerializeField] AudioSource darkAmbientTheWander;
    [SerializeField] AudioSource stepsDefault;
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
    private float _storedMana;
    private float _storedHealth;
    private float _manaRegenTimer = 2f;
    private float _manaRegenCounter;
    #endregion

    #region Spells
    public bool _isUsingSpell;
    public bool _isPlayingFX;
    #endregion

    #region FXs
    [SerializeField] GameObject ManaParticles;
    #endregion

    #region PlayerInfo
    [SerializeField] GameObject Player;
    [SerializeField] PlayerData PlayerData;
    #endregion

    #region SAVE&LOAD
    private PlayerCurrentInfo playerCurrentInfo;
    #endregion

    void Awake()
    {
        PlayerData._currentHealth = PlayerData._maxHealth;
        PlayerData._currentMana = PlayerData._maxMana;
        _storedHealth = PlayerData._maxHealth;
        _storedMana = PlayerData._maxMana;

        playerCurrentInfo = FindObjectOfType<PlayerCurrentInfo>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) && !_gameIsPaused && SceneManager.GetActiveScene().buildIndex!=0)
        {
            PauseGame();
            _gameIsPaused = true;
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
            ManaSlider.SetMana(PlayerData._currentMana);
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
            ManaSlider.SetMana(PlayerData._currentMana);
        }

        if (_storedHealth == PlayerData._currentHealth)
        {
            return;
        }
        else { HealthSlider.SetHealth(PlayerData._currentHealth);  }
        if (_storedMana == PlayerData._currentMana)
        {
            return;
        }
        else { ManaSlider.SetMana(PlayerData._currentMana); }


        if (!_isUsingSpell && _manaRegenCounter > _manaRegenTimer)
        {
            Debug.Log("Regen Mana");
            PlayerData._currentMana += 0.05f;
        }

        if (PlayerData._currentMana <= 0 || !_isUsingSpell)
        {
            Debug.Log(PlayerData._currentMana);
            _manaRegenTimer += Time.deltaTime;
        }


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

