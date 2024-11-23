using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public char key;
    public ComputerScreen screen;
    protected virtual void start()
    {
        screen = FindFirstObjectByType<ComputerScreen>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            screen.AddKeyToSentence(key);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log(key.ToString() + " released!");
        }
    }
}
