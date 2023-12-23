using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class FarmerDialogue : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject dialoguePanelUI;
    [SerializeField] private TMP_Text dialogueTextUI;
    [SerializeField] private TextAsset fullText;

    private string[] dialogueLines;
    private float typeSpeed = 0.05f;
    private bool dialoguePlaying;   //if there is dialogue showing on the screen
    private bool startDialogue;

    private int lineIndex = 0;
    void Start()
    {
        readText();
        dialoguePlaying = false;
        startDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startDialogue)
        {
            if (!dialoguePlaying)
            {
                StartDialogue();

            }
            //if dialogue panel is showing a complete dialogue line, and we want to continue to the next one
            // we have to check if we aren't on an event, bc if we are in one and we press Space, it gets stuck
            else if (lineIndex < dialogueLines.Length && dialogueTextUI.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            //if we want to show the next line but current one didn't finish to show completely
            /*else if (dialogueTextUI.text != dialogueLines[lineIndex])
            {
                StopAllCoroutines();
                dialogueTextUI.text = dialogueLines[lineIndex];
            }*/
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Holi");
        if (other.gameObject.tag =="Player")
        {
            startDialogue = true;
        }
    }

    private void readText()
    {
        //We will read names and comunicate with the component 'ChangeDialogueSprintes' of the CinematicManager

        dialogueLines = fullText.text.Split('\n');
    }

    private void StartDialogue()
    {
        dialoguePlaying = true;
       // dialoguePanelUI.SetActive(true);
        lineIndex = 0;
        StartCoroutine(showLine());
    }
    private IEnumerator FinishDialogue()
    {
        yield return new WaitForSecondsRealtime(2f);
        dialoguePanelUI.SetActive(false);
        this.enabled = false;

    }

    private void NextDialogueLine()
    {
        lineIndex++;

        //if there still are dialogue lines to show
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(showLine());
        }
        else  //whole dialogue is finished
        {
            StartCoroutine(FinishDialogue());
        }
    }

    private IEnumerator showLine()
    {
        yield return new WaitForSecondsRealtime(2f);
        dialogueTextUI.text = string.Empty;
        dialoguePanelUI.SetActive(true);

        if (lineIndex == 0 || lineIndex == 6)
        {
            StartCoroutine(farmerOne());

        }else if (lineIndex == 2 || lineIndex == 4)
        {
            StartCoroutine(farmerTwo());
        }
        
        //we gonna show each dialogue line character by character
        foreach (char c in dialogueLines[lineIndex])
        {
            dialogueTextUI.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

    }

    private IEnumerator farmerOne()
    {
        Debug.Log("Animacion 1");
        animator.SetInteger("State", 1);
        if(lineIndex == 0)
        {
            yield return new WaitForSecondsRealtime(1f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(2f);
        }
        animator.SetInteger("State", 0);
    }

    private IEnumerator farmerTwo()
    {
        Debug.Log("Animacion 2");
        animator.SetInteger("State", -1);
        yield return new WaitForSecondsRealtime(2f);
        animator.SetInteger("State", 0);
    }

}

