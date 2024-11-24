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

    public int currentAssignment = 0;
    public TextMeshPro assignmentText;
    public ScoreManager scoreManager;

    public Animator paperAnim;

    public RandomDrop randomDrop;

    //public MainComputerScreen screen;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        //screen = FindFirstObjectByType<MainComputerScreen>();//use dotween to translate
        StartFirstAssignment();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckPlayerText()
    {
        if(MainComputerScreen.instance.playerTypedSentence == assignmentList[currentAssignment])
        {
            paperAnim.SetTrigger("Fall");
            Invoke("AssignmentReset", 1f); //The 1f here is saying "Call this function after 1 swcond!!!!!!!!! may need to change later

            currentAssignment++;
            assignmentText.text = assignmentList[currentAssignment];

            scoreManager.score++;
            Debug.Log("correct text"); 
        }

        if (MainComputerScreen.instance.playerTypedSentence != assignmentList[currentAssignment])
        {
            Debug.Log("incorrect text");
        }
    }

    public void StartFirstAssignment()
    {
        assignmentText.text = assignmentList[currentAssignment];
        //DoAnimationStuff
    }

    public void AssignmentReset()
    {
        AssignmentPaper.transform.position = AssignmentStartPos.transform.position;
        AssignmentPaper.GetComponent<MeshRenderer>().material = materials[currentAssignment];
        paperAnim.SetTrigger("Print");
        randomDrop.Drop();
    }
}
