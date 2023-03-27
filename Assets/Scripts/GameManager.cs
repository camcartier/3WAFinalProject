using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Sound
    [SerializeField] AudioSource _menuBackgroundMusic;
    [SerializeField] AudioSource _meadowBackgroundMusic;
    #endregion

    #region Pause
    public bool _gameIsPaused;
    public bool _gameIsPlaying;
    #endregion

    #region Unlocks
    public bool _hasFire;
    public bool _hasIce;
    public bool _hasBoots;
    public bool _hasCape;
    public bool _hasSword;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_gameIsPaused)
        {
            PauseGame();
            _gameIsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _gameIsPaused)
        {
            ResumeGame();
            _gameIsPaused = false;
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

