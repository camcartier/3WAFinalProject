using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Sound
    [SerializeField] AudioSource _menuBackgroundMusic;
    [SerializeField] AudioSource _meadowBackgroundMusic;

    #endregion

    #region Pause
    public bool _isPaused;
    public bool _isPlaying;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
