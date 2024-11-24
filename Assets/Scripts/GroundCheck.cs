using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public RigidbodyPlayerController playerController;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter :) " + other.gameObject.name);
        if (other.gameObject == playerController.gameObject)
            return;
        playerController.SetGrounded(true);

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit :) " + other.gameObject.name);
        if (other.gameObject == playerController.gameObject)
            return;
        playerController.SetGrounded(false);

    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay :) " + other.gameObject.name);
        if (other.gameObject == playerController.gameObject)
            return;
        playerController.SetGrounded(true);

    }
}
