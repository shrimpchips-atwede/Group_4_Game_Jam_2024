using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public AudioSource keySound;
    public char key;
    //public MainComputerScreen screen;
    protected virtual void start()
    {
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

        MainComputerScreen.instance.AddKeyToSentence(key);
        Debug.Log("key");

    }
    protected virtual void KeyRelease()
    {
        Debug.Log("you shouldnt see this on key release");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            KeyRelease();
        }
    }
}
