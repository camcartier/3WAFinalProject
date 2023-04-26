using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerIceAndLava : MonoBehaviour
{
    public float _iceCoyoteTime = 2f;
    private float _iceTimer;
    public float _lavaCoyoteTime = 2f;
    private float _lavaTimer;

    [SerializeField] PlayerData PlayerData;
    [SerializeField] GameManager GameManager;

    [SerializeField] GameObject MessagePanel;
    [SerializeField] TMP_Text _messageTXT;
    //[SerializeField] GameObject MessagePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_iceTimer > _iceCoyoteTime)
        {
            //Debug.Log("freezing!");
            _messageTXT.text = ("you are freezing!");
            PlayerData._currentHealth -= 0.03f;
        }

        if (_lavaTimer > _lavaCoyoteTime)
        {
            //Debug.Log("burning!");
            _messageTXT.text = ("you are burning!");
            PlayerData._currentHealth -= 0.07f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            MessagePanel.SetActive(true);
            _messageTXT.text = ("it's too cold");
            //Debug.Log("it's too cold");
        }
        if (other.CompareTag("Lava"))
        {
            MessagePanel.SetActive(true);
            _messageTXT.text = ("it's too hot");
            //Debug.Log("it's too hot");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            
            _iceTimer += Time.deltaTime;
        }

        if (other.CompareTag("Lava"))
        {
            
            _lavaTimer += Time.deltaTime;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            MessagePanel.SetActive(false);
            _iceTimer = 0f;
            Debug.Log(" iced over ");
        }

        if (other.CompareTag("Lava"))
        {
            MessagePanel.SetActive(false);
            _lavaTimer = 0f;
            Debug.Log(" toasted out ");
        }
    }
}
