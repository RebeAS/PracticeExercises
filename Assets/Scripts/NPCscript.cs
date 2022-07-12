using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : Interactable
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    public enum NPCstates
    { talking, notTalking }

    private NPCstates currentState = NPCstates.notTalking;

    private void Start()
    {
        DialogueManager.Instance.OnDialogueEnd += StopTalking;
    }

    public void StopTalking()
    {
        currentState = NPCstates.notTalking;
    }

    public override void Interact()
    {
        switch (currentState)
        {
            case NPCstates.talking:
                dialogueTrigger.NextSentence();
                break;

            case NPCstates.notTalking:
                dialogueTrigger.StartDialogue();
                currentState = NPCstates.talking;
                break;

            default:
                break;
        }
    }
}