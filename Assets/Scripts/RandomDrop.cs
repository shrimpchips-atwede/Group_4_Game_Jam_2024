using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    public List<GameObject> randDrops = new List<GameObject>();

    public Assignments assignments;
    public GameObject spawnloc;
    public Light halo;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Drop();
        }
    }
    public void Drop()
    {


        GameObject go = Instantiate(randDrops[assignments.currentAssignment], spawnloc.transform);

        Destroy(go, 7f);

    }
}
