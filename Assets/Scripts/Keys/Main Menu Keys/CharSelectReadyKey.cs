using UnityEditor;
using UnityEngine;

public class CharSelectReadyKey : Key
{
    public MainMenu menu;
    public bool CanGameStart = false;

    public int charSelectPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        menu = FindFirstObjectByType<MainMenu>();
    }
    protected override void KeyPress()
    {
        if(charSelectPlayer == 0)
        {
            menu.isPlayer1Ready = !menu.isPlayer1Ready;
        }
        else if (charSelectPlayer == 1)
        {
            menu.isPlayer2Ready = !menu.isPlayer2Ready;
        }

    }

}
