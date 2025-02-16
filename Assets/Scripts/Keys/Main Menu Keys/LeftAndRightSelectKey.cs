using UnityEngine;


public class LeftAndRightSelectKey : Key
{
    public int charSelectPlayer;//set this to 1 or 2 depending on which player it is being used for
    public bool firstPress = true;
    public GameObject player;
    public PlayerData playerData;
    public bool isRightKey;
    public PlayerProfileUI playerProfileUI;
    public UpAndDownSelectKey upAndDownSelectKey1;
    public UpAndDownSelectKey upAndDownSelectKey2;
    public LeftAndRightSelectKey leftAndRightSelectKey3;



    //public float scrollProfileTimer = 0f;
    //public float scrollProfileTimerDuration = 100f;
    //public bool isCounting = false;


    void Update()
    {
        if (player == null)
        {
            if(isRightKey)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < players.Length; i++)
                {

                    if (players[i].GetComponent<PlayerData>().playerNumber == charSelectPlayer)
                    {
                        player = players[i];
                        playerData = player.GetComponent<PlayerData>();
                        upAndDownSelectKey1.playerData = playerData;
                        upAndDownSelectKey2.playerData = playerData;
                        leftAndRightSelectKey3.playerData = playerData;
                        //this is really dumb. use an event? ask anthony bc i know im doing this wrong

                        playerProfileUI.ChangePlayerProfileUI(playerData);
                        Debug.Log("update playerdataui for player" + playerData.playerProfileNumber);
                        //Debug.Log(player.name);
                        break;

                    }

                }
            }


        }
        //if (isCounting && player != null) { ProfileScrollTimer(); Debug.Log(scrollProfileTimer); }

    }



    protected override void KeyPress()
    {
        //why u no work
        Debug.Log("Right" + isRightKey + "isPressed");

        PlayerProfiles.instance.UpdateProfileMenu(isRightKey, playerData, playerProfileUI);
        playerProfileUI.UpdateProfileMenuUI(playerData);
        //base.KeyPress();


    }
    //public void OnTriggerStay(Collider other)
    //{
    //    if (!isCounting && player != null && other.tag == "Key") 
    //    {
    //        isCounting = true;
    //    }
    //    Debug.Log(other.name);

    //}
    //protected override void KeyRelease()
    //{
    //    scrollProfileTimer = 0f;
    //    isCounting = false;
    //}

    //private void ProfileScrollTimer()
    //{

    //    scrollProfileTimer += Time.deltaTime; //Timer increases by the time between frames (at a rate of 1 second per second)

    //    if (scrollProfileTimer >= scrollProfileTimerDuration) 
    //    {
    //        KeyPress();
    //        scrollProfileTimer = 0f;
    //    }

    //}
}
