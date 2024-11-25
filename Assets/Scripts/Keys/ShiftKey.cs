using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftKey : Key
{


    protected override void KeyPress()
    {
        if (audioSource != null)
        {
            Debug.Log("audiosourceisnotnull");
            audioSource.Play();
            Debug.Log("played sound");
        }
        MainComputerScreen.instance.isShiftHeldDown = true;
        Debug.Log("shift is  held down: " + MainComputerScreen.instance.isShiftHeldDown);
    }
    protected override void KeyRelease()
    {
        MainComputerScreen.instance.isShiftHeldDown = false;
        Debug.Log("shift is  held down: " + MainComputerScreen.instance.isShiftHeldDown);
    }
}
