using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Collider playerCollider;
    public float speed, sensitivity, maxForce;
    private Vector2 move;
    private float lookRotation;

    public bool isGrounded;
    public float jumpForce;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();

    }
    private void FixedUpdate()
    {
        Move();
        //Jump();


    }
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Move()
    {
        //find target velocity
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);//what we were trying to do earlier!!!
        targetVelocity *= speed;

        //align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //calc forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);


        Vector3.ClampMagnitude(velocityChange, maxForce);
                //limit force
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        
    }
    void Jump()
    {

        Vector3 jumpForces = Vector3.zero;
        if(isGrounded)
        {
            jumpForces = Vector3.up * jumpForce;

        }
        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }
    public void SetGrounded(bool state)
    {
        isGrounded = state;
    }
}
