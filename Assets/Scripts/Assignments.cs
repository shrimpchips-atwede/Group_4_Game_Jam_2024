using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Assignments : MonoBehaviour
{
    public List<string> assignmentList = new List<string>();
    public int currentAssignment = 0;
    public TextMeshPro assignmentText;
    public ScoreManager scoreManager;
    //public MainComputerScreen screen;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        //screen = FindFirstObjectByType<MainComputerScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckPlayerText()
    {
        if(MainComputerScreen.instance.playerTypedSentence == assignmentList[currentAssignment])
        {
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
}
