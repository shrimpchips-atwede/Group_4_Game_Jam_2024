using UnityEngine;

public class FearKey : Key
{
    public Light scenelight1;
    public Light scenelight2;

    protected override void KeyPress()
    {
        if (audioSource != null)
        {
            Debug.Log("audiosourceisnotnull");
            audioSource.Play();
            Debug.Log("played sound");
        }

        if (scenelight1.enabled && scenelight2.enabled)
        {
            MainComputerScreen.instance.PressFear();
            scenelight1.enabled = !scenelight1.enabled;
            scenelight2.enabled = !scenelight2.enabled;
        }
        else
        {
            MainComputerScreen.instance.PressClear();
            scenelight1.enabled = !scenelight1.enabled;
            scenelight2.enabled = !scenelight2.enabled;
        }



    }
}
