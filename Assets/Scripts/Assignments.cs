using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Assignments : MonoBehaviour
{
    public List<string> assignmentList = new List<string>();
    public List<Material> materials = new List<Material>();
    public List<string> storyAssignmentList = new List<string>();
    public List<string> endlessAssignmentList = new List<string>();

    public GameObject AssignmentStartPos;
    public GameObject AssignmentPaper;

    public SkinnedMeshRenderer assignmentPaperRenderer;

    public int currentAssignment = 0;
    //public TextMeshPro assignmentText;
    public ScoreManager scoreManager;

    public Animator paperAnim;

    public RandomDrop randomDrop;
    public AudioSource printersound;
    public AudioSource fallsound;

    public TextMeshPro endlessText;

    //public MainComputerScreen screen;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        if (ScoreManager.instance.gameMode == 1)
        {
            assignmentPaperRenderer.material = materials[10];
            assignmentList = endlessAssignmentList;

        }
        else
        {
            assignmentList = storyAssignmentList;
        }


    }

    public void CheckPlayerText()
    {
        if(MainComputerScreen.instance.playerTypedSentence == assignmentList[currentAssignment])
        {
            if(ScoreManager.instance.gameMode == 1)
            {
                assignmentList.RemoveAt(currentAssignment);

                if (MainComputerScreen.instance.endlessAssignmentCounter > 0)
                {
                    MainComputerScreen.instance.EndlessTimerCompleteAssignment();
                }


            }

            paperAnim.SetTrigger("Fall");
            fallsound.Play();

            Invoke("AssignmentReset", 1f);


            if (currentAssignment == assignmentList.Count)
            {
                ScoreManager.instance.EndGame();
            }




            if (ScoreManager.instance.gameMode == 0)
            {
                currentAssignment++;
            }

            scoreManager.score++;
            Debug.Log("correct text"); 
        }

        if (MainComputerScreen.instance.playerTypedSentence != assignmentList[currentAssignment])
        {
            Debug.Log("incorrect text");
            //this is where id put in buzzer sound effect
        }
    }

    public void StartFirstAssignment()
    {
        //assignmentText.text = assignmentList[currentAssignment];//would set assignment text
        if (ScoreManager.instance.gameMode == 1)
        {
            endlessText.text = assignmentList[currentAssignment];

        }

        AssignmentReset();//maybe?????
    }

    public void AssignmentReset()
    {

        MainComputerScreen.instance.PressClear();

        AssignmentPaper.transform.position = AssignmentStartPos.transform.position;

        if (ScoreManager.instance.gameMode == 0)
        {

            assignmentPaperRenderer.material = materials[currentAssignment];
        }
        else if (ScoreManager.instance.gameMode == 1)
        {

            currentAssignment = Random.Range(0, assignmentList.Count);
            endlessText.text = assignmentList[currentAssignment];
        }

        paperAnim.SetTrigger("Print");
        printersound.Play();

        if (assignmentList[currentAssignment] == "ball")
        {
            randomDrop.Drop(0);
        }
        if (assignmentList[currentAssignment] == "banana")
        {
            randomDrop.Drop(1);
        }
        if (assignmentList[currentAssignment] == "bowling")
        {
            randomDrop.Drop(2);
        }



    }
}
