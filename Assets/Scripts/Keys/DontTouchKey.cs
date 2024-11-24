using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouchKey : Key
{
    public RandomDrop randDrop;


    protected override void start()
    {
        base.start();
        randDrop = FindFirstObjectByType<RandomDrop>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Key")
        {
            randDrop.Drop(2);
        }

    }
}
