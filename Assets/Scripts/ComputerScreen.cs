using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerScreen : MonoBehaviour
{
    //public List<string> sentences = new List<string>();
    //private int sentenceIndex = 0;

    //public string currentSentence = "Hello!";

    public string playerTypedSentence = string.Empty;

    public bool isShiftHeldDown = false;
    public bool isCapsLockOn = false;

    public TextMeshPro playerText;

    // Start is called before the first frame update
    void Start()
    {
        //currentSentence = sentences[0];
        playerText.text = playerTypedSentence;
        Debug.Log(playerText.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKeyToSentence(char character)
    {
        if(isShiftHeldDown)
        {
            if(isCapsLockOn)
            {
                playerTypedSentence = character.ToString();
            }
            else
            {
                playerTypedSentence += char.ToUpper(character);
            }
        }
        else
        {
            if (isCapsLockOn)
            {
                playerTypedSentence += char.ToUpper(character);
            }
            else
            {
                playerTypedSentence += character.ToString();
            }  
        }

        playerText.text = playerTypedSentence;

        //CheckIfSentenceComplete();
    }

    public void ToggleShiftKey(bool isOn)
    {
        isShiftHeldDown = isOn;
    }


    public void PressBackspace()
    {
        if(playerTypedSentence.Length > 0)
        {
            playerTypedSentence.Remove(playerTypedSentence.Length - 1);
            playerText.text = playerTypedSentence;
        }
    }
    public void PressClear()
    {
        if (playerTypedSentence.Length > 0)
        {
            playerTypedSentence = string.Empty;
            playerText.text = playerTypedSentence;
        }
    }

    //public void CheckIfSentenceComplete()
    //{
    //    if(currentSentence.Equals(playerTypedSentence))
    //    {
    //        ShowNextSentence();
    //    }
    //}

    //public void ShowNextSentence()
    //{
    //    sentenceIndex++;

    //    currentSentence = sentences[sentenceIndex];

    //    playerTypedSentence = string.Empty;
    //    playerText.text = playerTypedSentence;
    //}

}
