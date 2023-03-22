using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dilogueText;
    public Animator animator;
    public Queue<string> sentences;
    public Canvas[] canvases;
    public Canvas canvasDialogue;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        foreach (Canvas canvas in canvases)
        {

            canvas.enabled = false;
        }
        //activate child canvas;
        canvasDialogue.enabled = true;

        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        Debug.Log("Starting conversation with" + dialogue.name);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dilogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dilogueText.text += letter;
            yield return null;
        }

    }
    void EndDialogue()
    {

        Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
        foreach (Canvas canvas in canvases)
        {

            canvas.enabled = true;
        }
        //activate child canvas;
        canvasDialogue.enabled = false;
    }
   
}
