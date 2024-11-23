using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public char key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log(key.ToString() + " pressed!");
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
