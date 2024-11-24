using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Assignments : MonoBehaviour
{
    public List<string> assignmentList = new List<string>();
    public List<Material> materials = new List<Material>();

    public GameObject AssignmentStartPos;
    public GameObject AssignmentPaper;

    public SkinnedMeshRenderer assignmentPaperRenderer;

    public int currentAssignment = 0;
    //public TextMeshPro assignmentText;
    public ScoreManager scoreManager;

    public Animator paperAnim;

    public RandomDrop randomDrop;

    //public MainComputerScreen screen;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        //screen = FindFirstObjectByType<MainComputerScreen>();//use dotween to translate

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartFirstAssignment();
        }

    }
    public void CheckPlayerText()
    {
        if(MainComputerScreen.instance.playerTypedSentence == assignmentList[currentAssignment])
        {
            paperAnim.SetTrigger("Fall");
            Invoke("AssignmentReset", 1f); //The 1f here is saying "Call this function after 1 swcond!!!!!!!!! may need to change later
            Debug.Log("fall animation");
            //this is where id assign a dotween thing
            currentAssignment++;
            //assignmentText.text = assignmentList[currentAssignment];

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
        
        AssignmentReset();//maybe?????
    }

    public void AssignmentReset()
    {
        MainComputerScreen.instance.PressClear();

        AssignmentPaper.transform.position = AssignmentStartPos.transform.position;
        assignmentPaperRenderer.material = materials[currentAssignment];
        paperAnim.SetTrigger("Print");
        Debug.Log("print animation");
        //do dotween stuff here
        if (currentAssignment == 1)
        {
            randomDrop.Drop(0);
        }
        if (currentAssignment == 4)
        {
            randomDrop.Drop(1);
        }
        if (currentAssignment == 6)
        {
            randomDrop.Drop(2);
        }


    }
}
