using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKey : Key
{
    // Start is called before the first frame update
    protected override void KeyPress()
    {
        MainComputerScreen.instance.PressClear();

    }

}
