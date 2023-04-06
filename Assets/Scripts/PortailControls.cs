using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailControls : MonoBehaviour
{
    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("coucou");
            GameManager.LoadNextScene();
        }
    }
}
