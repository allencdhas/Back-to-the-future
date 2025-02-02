using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogurManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    public float nextMessageInterval;
    public float initialDelay;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    public GameObject dialogueCanvas;

    public void OpenDialogue(Message[] messages,Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("started" + messages.Length);
        DisplayMessages();

    }

    void DisplayMessages()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite; 
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessages();
        }
        else
        {
            Debug.Log("convo done");
            isActive = false;
            dialogueCanvas.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NextMessage", initialDelay, nextMessageInterval);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive==true)
        {
            NextMessage();
        }

                

    }
}
