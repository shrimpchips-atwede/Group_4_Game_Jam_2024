using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RigidbodyPlayerController : MonoBehaviour
{
    //From claire: in the script:
    //at the top with the variables
    //you'll have private animator anim,
    //then in start youll do anim = getcomponent animator.
    //in the animator in unity: set up the bools, isWalking
    //, isJumping, whatever else. then back in the script
    //when movement is being used, you will say something
    //like if movementvelocity > 0 then isWalking is true
    //and otherwise its false. then for the jump, if !isgrounded then isJumping = true
    private Animator animator;
    public Rigidbody rb;
    public Collider playerCollider;
    public float speed, sensitivity, maxForce;
    private Vector2 move;
    private float lookRotation;

    public bool isGrounded;
    public float jumpForce;

    public bool isMoving;
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        move = context.ReadValue<Vector2>();
        if(move != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

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


    // Update is called once per frame
    void Update()
    {

        //if (rb.velocity == Vector3.zero);
        //{
        //    isMoving = false;
        //    Debug.Log(isMoving);
        //}
        //isMoving = true;
    }
    void Move()
    {
        //movementvelocity > 0 then isWalking is true

        //find target velocity
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);//what we were trying to do earlier!!!
        targetVelocity *= speed;

        //align direction
        //targetVelocity = transform.TransformDirection(targetVelocity);

        //calc forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);


        Vector3.ClampMagnitude(velocityChange, maxForce);
                //limit force
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 targetDirection3D = new Vector3(move.x, 0, move.y);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection3D, Vector3.up);
        transform.rotation = targetRotation;

    }
    void Jump()
    {

        Vector3 jumpForces = Vector3.zero;
        if(isGrounded)
        {
            animator.SetBool("isJumping", true);
            jumpForces = Vector3.up * jumpForce;

        }
        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }
    public void SetGrounded(bool state)
    {
        isGrounded = state;
        if(isGrounded == false)
        {
            animator.SetBool("isJumping", false);
        }
    }
}
