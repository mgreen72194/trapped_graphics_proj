using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; } // Singleton instance
    public List<string> dialogueList;
    public GameObject dialoguePanel;
    Button continueBtn;
    Text dialogueText;
    int dialogueIndex;

	// Use this for initialization
	void Start () {
        dialogueIndex = 0;
        continueBtn = dialoguePanel.transform.Find("Button").GetComponent<Button>();
        continueBtn.onClick.AddListener(delegate{ ContinueDialogue(); });
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();

        dialogueList = new List<string>();
        dialogueList.Add("Welcome to Trapped!");
        dialogueList.Add("The goal of this level is finding the portal.");
        dialogueList.Add("Also try to find some collectible objects along the way");

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        CreateDialogue();
	}

    public void CreateDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueList[dialogueIndex];
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueList.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueList[dialogueIndex];
        }
        else
            dialoguePanel.SetActive(false);
    }
}
