using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2TxtManager : MonoBehaviour
{
    [SerializeField] GameObject DialoguePanel;
    [SerializeField] TextMeshProUGUI IntroTXT;
    [SerializeField] GameObject ContinueButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DialogueAppears());
        //StartCoroutine(SurpriseAppears());
    }

    /*
    private IEnumerator SurpriseAppears()
    {
        yield return new WaitForSeconds(0.2f);
        SurprisePanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SurprisePanel.SetActive(false);
    }
    */

    private IEnumerator DialogueAppears()
    {
        yield return new WaitForSeconds(0.2f);
        DialoguePanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        IntroTXT.text = ("I can get through this if I go fast enough.");
        yield return new WaitForSeconds(1f);
        ContinueButton.SetActive(true);
    }

    public void DisablePanel()
    {
        DialoguePanel.SetActive(false);
    }
}
