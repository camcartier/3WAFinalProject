using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("DialogueScene1", LoadSceneMode.Single);
       // SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }
}