using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterKey : Key
{
    public Assignments assignments;
    // Start is called before the first frame update
    protected override void Start()
    {
        assignments = FindFirstObjectByType<Assignments>();
        base.Start();
    }
    protected override void KeyPress()
    {
        MainComputerScreen.instance.CheckPlayerTextMainComputer();
        Debug.Log(this.gameObject.name);

        if (audioSource != null)
        {
            Debug.Log("audiosourceisnotnull");
            audioSource.Play();
            Debug.Log("played sound");
        }

    }
}
