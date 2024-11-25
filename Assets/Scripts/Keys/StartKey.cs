using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKey : Key
{
    public bool isPlayer1Key = true;

    // Start is called before the first frame update
    protected override void KeyPress()
    {
        if (audioSource != null)
        {
            Debug.Log("audiosourceisnotnull");
            audioSource.Play();
            Debug.Log("played sound");
        }
        MainComputerScreen.instance.PlayerReady(isPlayer1Key, true);
    }

    protected override void KeyRelease()
    {
        MainComputerScreen.instance.PlayerReady(isPlayer1Key, false);

    }
}
