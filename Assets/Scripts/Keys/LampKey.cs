using UnityEngine;

public class LampKey : Key
{
    public Light lamplight;
    public bool isLampOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void KeyPress()
    {
        Debug.Log("fart");
        if(isLampOn == true)
        {

            //lamplight.enabled = false;
            isLampOn = false;
        }
        else if (isLampOn == false)
        {

            //lamplight.enabled = true;
            isLampOn = true;
        }

    }
}
