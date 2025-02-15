using Cinemachine;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CinemachineTargetGroup targetGroup;
    //public CinemachineTargetGroup.Target[] m_Targets;
    public float weight = 1f;
    public float radius = 50f;
    public bool followingTargets = false;


    public void Start()
    {
        targetGroup = FindAnyObjectByType<CinemachineTargetGroup>();
    }
    public void Update()
    {
        if(!followingTargets)
        {
            FindTargets();
        }

    }
    public void FindTargets()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length == 2 )
        {
            foreach (GameObject player in players)
            {
                targetGroup.AddMember(player.transform, weight, radius);
            }
            followingTargets = true;
        }





    }
}
