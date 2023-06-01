using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterractMousey : MonoBehaviour
{
    [SerializeField] Animator MouseyAnimator;
    private float TriggerDelay = 3f;
    private float TriggerCounter;

    void Start()
    {
        MouseyAnimator.SetTrigger("waving");
    }

    void Update()
    {
        if (TriggerCounter < TriggerDelay)
        {
            TriggerCounter += Time.deltaTime;
        }
        else
        {
            MouseyAnimator.SetTrigger("waving");
            TriggerCounter = 0;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
