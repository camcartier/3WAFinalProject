using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoucanNowErase : MonoBehaviour
{
    [SerializeField] GameObject YoucanNowPanel;

    /*
    void Awake()
    {
        YoucanNowPanel = GameObject.Find("YoucanNowPanel");
    }*/
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(YoucanNowPanelErase());
    }

    private IEnumerator YoucanNowPanelErase()
    {
        yield return new WaitForSeconds(3f);
        YoucanNowPanel.SetActive(false);
    }
}
