using UnityEngine;

public class CharSelectKey : Key
{
    public int charSelectPlayer;
    public bool firstPress = true;
    public GameObject Player;
    public RigidbodyPlayerController rbpc;
    public int leftOrRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void KeyPress()
    {
        if (firstPress)
        {
            firstPress = false;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++)
            {
                if(i == charSelectPlayer)
                {
                    Player = players[i]; rbpc = Player.GetComponent<RigidbodyPlayerController>(); break;
                }
            }
        }
        rbpc.ChangePlayerMat(leftOrRight);
    }
}
