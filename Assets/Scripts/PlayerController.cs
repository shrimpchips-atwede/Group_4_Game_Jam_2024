using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{






    private Vector3 movement = Vector3.zero;
    public float speed = 5f;





    private float gravity = 9.1f;
    public float jumpHeight = 3f;
    private float verticalVelocity;
    private bool isJumpPressed = false;
    private float groundedTimer;
    public float groundedTimerBuffer = 0.2f;
    private bool isPlayerGrounded = true;


    public float lookSpeed = 10;
    private Vector3 curLoc;
    private Vector3 prevLoc;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*

        if (characterController.isGrounded == true)
        {
            groundedTimer = 0f;
            isPlayerGrounded = true;
        }

        else if (characterController.isGrounded == false)
        {
            groundedTimer += Time.deltaTime;
            if (groundedTimer > groundedTimerBuffer)
            {
                isPlayerGrounded = false;//this is the timer to give a buffer to the grounded thang
            }
        }

        if (isPlayerGrounded == true && verticalVelocity < 0f) //checks if ur grounded and if vertvelocity is less than 0
        {
            verticalVelocity = 0f;//resets value to 0 so it doesnt keep speeding up
        }
        if (isPlayerGrounded == false)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        if (isJumpPressed == true)
        {
            verticalVelocity += Mathf.Sqrt(jumpHeight * gravity);
            isJumpPressed = false;
            isPlayerGrounded = false;
        }
        Vector3 moveDir = movement * speed;
        moveDir.y = verticalVelocity;

        characterController.Move(moveDir * Time.deltaTime); //call char controller and tell it to move.
                                                            //if im not using the stock char controller,
                                                            //will have to make my own script for this...
        */
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isPlayerGrounded == true)
        {
            isJumpPressed = true;
        }
    }
    public void OnMove(InputAction.CallbackContext context) // onmove is called from our eventon the playerinput component.
                                                            // This context can check if its happening/canceled this frame,
                                                            // and check any values associated with it
    {
        if (context.performed == true)//check on frame key is pressed. 
        {
            //prevLoc = curLoc;
            //curLoc = transform.position;
            Debug.Log("moving");
            Vector2 moveDirection = context.ReadValue<Vector2>();//scary new syntax.
                                                                 //make temp var, set it to the key being pressed translated into a vector 2.
                                                                 //Means that it reads the value
                                                                 //of the buttons being pressed from our context variable. um whats our context variable???
                                                                 //i.e, it sees that player presses w, and returns (0,1). S is (0,-1). A is (-1, 0). D is (1,0).



            //Vector3 v3 = moveDirection;
            //Debug.Log(v3);
            //if (moveDirection.x >= 0)
            //{
            //    this.transform.rotation = QuaternionAngles.Rotate(v3, Vector3.zero);
            //}
            movement = new Vector3(moveDirection.x, 0f, moveDirection.y);
            //transform.position = curLoc;
            //transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), lookSpeed);
        }

        if (context.canceled == true)//check on frame key is released
        {
            movement = new Vector3(0f, 0f, 0f); // stop movement
        }


    }
    private void OnTriggerEnter()
    {
        //triggers still works with char controllers
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //this is for collisions w a character controller
    }
}
