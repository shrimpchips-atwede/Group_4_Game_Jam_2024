using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RaycastGroundCheck : MonoBehaviour
{
    public List<GameObject> raycastEmpties;
    public RigidbodyPlayerController playerController;



    public void Update()
    {

        for (int i = 0; i < raycastEmpties.Count; i++)
        {
            RaycastHit hit;

            if (Physics.Raycast(raycastEmpties[i].transform.position, Vector3.down, out hit, 0.2f))
            {
                //Debug.Log(go.name);
                //Debug.Log("Hitting :" + hit.collider.name);
                if (hit.collider.gameObject != playerController.gameObject)
                {
                    //Debug.Log("Grounded :)");
                    playerController.SetGrounded(true);
                    break;
                }
            }
            else
            {
                //Debug.Log(go.name);
                //Debug.Log("Not Grounded :(");
                playerController.SetGrounded(false);
            }

        }

    }

    //private void Update()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 0.2f))
    //    {
    //        Debug.Log("Hitting :" + hit.collider.name);
    //        if (hit.collider.gameObject != playerController.gameObject)
    //        {
    //            Debug.Log("Grounded :)");
    //            playerController.SetGrounded(true);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Not hitting anything");
    //        playerController.SetGrounded(false);
    //    }
    //}
    //make all 4 empty children raycast down. if anything is hit that is not a player, grounded is true. if nothing is hit, grounded is false
}
