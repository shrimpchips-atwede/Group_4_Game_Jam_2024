using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterKey : Key
{
    public Assignments assignments;
    // Start is called before the first frame update
    void Start()
    {
        //assignments = FindFirstObjectByType<Assignments>();
    }
    protected override void KeyPress()
    {
        MainComputerScreen.instance.CheckPlayerTextMainComputer();
        Debug.Log(this.gameObject.name);
    }
}
