using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;
    public Animator animator;

    //public bool dialogueIsFinished;

    private Queue<string> name;
    private Queue<string> sentences;

    private DialogueTrigger[] holderArray;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        name = new Queue<string>();

        holderArray = FindObjectsOfType<DialogueTrigger>();
    }

    /*
    public void OnEnable()
    {
        StartDialogue(dialogue);
    }*/

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("starting conversation with " + dialogue.name);

        //nameText.text = dialogue.name;

        sentences.Clear();
        name.Clear();

        foreach (string names in dialogue.name)
        {
            name.Enqueue(names);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string names = name.Dequeue();
        nameText.text = names;

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));


        //dialogueText.text = sentence;
        //Debug.Log(sentence);
    }

    /*
    public void DisplayNextNames()
    {
        /*
        if (name.Count == 0)
        {
            EndDialogue();
            return;
        }
        

        string names = name.Dequeue();


        nameText.text = names;
        //Debug.Log(sentence);
    }
    */


    public void EndDialogue()
    {
        if (holderArray.Length > 1)
        {
            Debug.Log("more");
            //ask for specific name +1 or smth
            //and enable next ?
        }
        else
        {
            Debug.Log("end of convo and fuuuuu");
            //whatever has to happen at each end of dialogue
            //let's make it load new scene

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }




        //mauvaise idee de poisson
        /*
        if (_dialogueIsFinished)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        */


    }


    //to make letters appear one by one
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.022f);
        }
    }



}



