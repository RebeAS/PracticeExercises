using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private Queue<string> dialogueQueue;

    [SerializeField] private Text NPCNameText;
    [SerializeField] private Text SentencesText;
    [SerializeField] private float TimeBetweenCharacters;

    public Animator MyAnimator;

    public System.Action OnDialogueEnd;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueQueue = new Queue<string>();
        NPCNameText.text = dialogue.NPCName;
        MyAnimator.SetBool("Show", true);
        foreach (string Sentence in dialogue.Sentences)
        {
            dialogueQueue.Enqueue(Sentence);
        }

        NextSentence();
    }

    public IEnumerator TypeSentence(string sentence)
    {
        string sentenceToType = "";
        for (int i = 0; i < sentence.Length; i++)
        {
            sentenceToType += sentence[i];
            SentencesText.text = sentenceToType;
            yield return new WaitForSeconds(TimeBetweenCharacters);
        }
    }

    public void NextSentence()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            string sentence = dialogueQueue.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    public void EndDialogue()
    {
        MyAnimator.SetBool("Show", false);
        Debug.Log("End of dialogue.");

        if (OnDialogueEnd != null)
        {
            OnDialogueEnd();
        }
    }
}