using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuotInterract : MonoBehaviour
{
    [SerializeField] GameObject TuotPanel;
    [SerializeField] Animator TuotAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player in");
            TuotPanel.SetActive(true);
            TuotAnimator.SetTrigger("Talking");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player out");
            TuotPanel.SetActive(false);
        }
    }
}
