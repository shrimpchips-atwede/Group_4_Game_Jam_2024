using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Material material1;
    public Material material2;
    void Start()
    {
        int players = GameObject.FindGameObjectsWithTag("Player").Length;
        if (players == 1)
        {
            skinnedMeshRenderer.material = material1;
        }
        else 
        {
            skinnedMeshRenderer.material = material2;
        }
    }

}
