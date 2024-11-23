using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftKey : Key
{


    protected override void KeyPress()
    {
        MainComputerScreen.instance.isShiftHeldDown = true;
        Debug.Log("shift is  held down: " + MainComputerScreen.instance.isShiftHeldDown);
    }
    protected override void KeyRelease()
    {
        MainComputerScreen.instance.isShiftHeldDown = false;
        Debug.Log("shift is  held down: " + MainComputerScreen.instance.isShiftHeldDown);
    }
}
