using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public RigidbodyPlayerController playerController;


    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(this.transform.position, Vector3.down, out hit, 0.2f))
        {
            Debug.Log("Hitting :" + hit.collider.name);
            if(hit.collider.gameObject != playerController.gameObject)
            {
                Debug.Log("Grounded :)");
                playerController.SetGrounded(true);
            }
        }
        else
        {
            Debug.Log("Not hitting anything");
            playerController.SetGrounded(false);
        }
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter :) " + other.gameObject.name);
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
        {
            Debug.Log("PLAYER");
            return;

        }
        playerController.SetGrounded(true);

    }*/
}
