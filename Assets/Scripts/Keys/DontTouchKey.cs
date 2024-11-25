using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouchKey : Key
{
    public RandomDrop randDrop;

     
    protected override void Start()
    {
        base.Start();
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
