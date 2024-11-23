using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
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
            KeyPress();
        }

    }
    protected virtual void KeyPress()
    {
        MainComputerScreen.instance.AddKeyToSentence(key);

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
