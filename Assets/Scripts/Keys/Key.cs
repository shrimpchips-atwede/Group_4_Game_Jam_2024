using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public AudioSource keySound;
    public char key;

    public AudioSource audioSource;
    //public MainComputerScreen screen; 
    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //screen = FindFirstObjectByType<MainComputerScreen>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            //keySound.Play();
            KeyPress();

        }

    }
    protected virtual void KeyPress()
    {
        //Debug.Log("before press" + key);
        if (MainComputerScreen.instance != null)
        {
            MainComputerScreen.instance.AddKeyToSentence(key);
        }
        //Debug.Log(key);

        if(audioSource != null)
        {
            //Debug.Log("audiosourceisnotnull");
            audioSource.Play();
            //Debug.Log("played sound");
        }

    }
    protected virtual void KeyRelease()
    {
        Debug.Log("key release base");
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            KeyRelease();
        }
    }
}
