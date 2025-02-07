using UnityEngine;


public class LeftAndRightSelectKey : Key
{
    public int charSelectPlayer;//set this to 1 or 2 depending on which player it is being used for
    public bool firstPress = true;
    public GameObject player;
    public PlayerData playerData;
    public bool RightKey;

    void Update()
    {
        if (player == null)
        {

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            {
                //Debug.Log(players.Length);
                for (int i = 0; i < players.Length; i++)
                {

                    if (players[i].GetComponent<PlayerData>().playerNumber == charSelectPlayer)
                    {
                        player = players[i];
                        playerData = player.GetComponent<PlayerData>();
                        //Debug.Log(player.name);
                        break;

                    }

                }


            }
        }

        if (Input.GetKeyDown(KeyCode.L))//just for playtesting/getting players unstuck
        {
            KeyPress();
        }
    }

    protected override void KeyPress()
    {
        //why u no work
        Debug.Log("Right" + RightKey + "isPressed");
        playerData.ChangePlayerProfile(RightKey);


    }
}
