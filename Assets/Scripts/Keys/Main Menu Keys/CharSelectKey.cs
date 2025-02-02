using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharSelectKey : Key
{
    public int charSelectPlayer;//set this to 1 or 2 depending on which player it is being used for
    public bool firstPress = true;
    public GameObject player;
    public RigidbodyPlayerController rbpc;
    public bool leftOrRight;

    protected override void Start()
    {
        base.Start();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (GetComponent<PlayerData>().playerNumber == charSelectPlayer)
                {
                    player = players[i];
                    break;
                }
            }


        }
    }
    protected override void KeyPress()
    {
        if (firstPress)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (GetComponent<PlayerData>().playerNumber == charSelectPlayer)
                    {
                        player = players[i];
                        firstPress = false;
                        break;
                    }
                }


            }
            firstPress = false;

        }

        player.GetComponent<PlayerData>().ChangePlayerProfile(leftOrRight);

    }
}
