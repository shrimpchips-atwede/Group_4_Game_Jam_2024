using UnityEngine;


public class LeftAndRightSelectKey : Key
{
    public int charSelectPlayer;//set this to 1 or 2 depending on which player it is being used for
    public bool firstPress = true;
    public GameObject player;
    public PlayerData playerData;
    public bool isRightKey;
    public PlayerProfileUI playerProfileUI;
    public UpAndDownSelectKey upAndDownSelectKey;




    //public float scrollProfileTimer = 0f;
    //public float scrollProfileTimerDuration = 100f;
    //public bool isCounting = false;


    void Update()
    {
        if (player == null)
        {

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0)
            {
                for (int i = 0; i < players.Length; i++)
                {

                    if (players[i].GetComponent<PlayerData>().playerNumber == charSelectPlayer)
                    {
                        player = players[i];
                        playerData = player.GetComponent<PlayerData>();
                        if (isRightKey) //int playerProfileNumber, int wagesCollected, float wpm, int levelsCompleted
                        {
                            playerProfileUI.UpdatePlayerDataUI(playerData);
                            Debug.Log("update playerdataui for player" + playerData.playerProfileNumber);
                        }
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

        PlayerProfiles.instance.UpdatePlayerData(isRightKey, playerData);
        playerProfileUI.UpdatePlayerDataUI(playerData);
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
