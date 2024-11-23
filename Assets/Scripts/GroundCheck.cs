using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public RigidbodyPlayerController playerController;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ground")
        {
            playerController.SetGrounded(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            playerController.SetGrounded(false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            playerController.SetGrounded(true);
        }
    }
}
