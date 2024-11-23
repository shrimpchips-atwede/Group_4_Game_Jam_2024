using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    // Start is called before the first frame update
    int numberOfObjectsToCreate = 5; // number of objects you want to spawn.
    float minTimeDiff = 1.0f; // minimum time difference between 2 objects spawned.
    float maxTimeDiff = 5.0f; // Maximam time difference between 2 spawns.
    public GameObject spawnpoint;
    public GameObject ObjectToSpawn; // object that is to be spawned;

    void Start()
    {
        StartCoroutine(CreateObjectsAtRandom());
    }

    IEnumerator CreateObjectsAtRandom()
    {
        for (int i = 0; i < numberOfObjectsToCreate; i++)
        {
            GameObject obj = Instantiate(ObjectToSpawn, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
            yield return new WaitForSeconds(Random.Range(minTimeDiff, maxTimeDiff)); // wait for a random time before spawning the next object.
        }
    }
}
