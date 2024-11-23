using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKey : Key
{
    public bool isPlayer1Key = true;

    // Start is called before the first frame update
    protected override void KeyPress()
    {
        MainComputerScreen.instance.PlayerReady(isPlayer1Key, true);
    }

    protected override void KeyRelease()
    {
        MainComputerScreen.instance.PlayerReady(isPlayer1Key, false);

    }
}
