using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue MyDialogue;

    public void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(MyDialogue);
    }

    public void NextSentence()
    {
        DialogueManager.Instance.NextSentence();
    }
}