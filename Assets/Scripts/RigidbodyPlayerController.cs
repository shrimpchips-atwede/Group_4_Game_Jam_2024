using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using static UnityEditor.PlayerSettings;


public class RigidbodyPlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator animator;
    public Rigidbody rb;
    public Collider playerCollider;
    public float speed, dashSpeed, baseSpeed, sensitivity, maxForce;
    private Vector2 move;
    private float lookRotation;

    public bool isGrounded;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public List<Material> materials;


    public bool isDashing;


    void Start()
    {

        playerInput = GetComponent<PlayerInput>();
        playerCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this);

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int numberOfPlayers = players.Length-1;

        skinnedMeshRenderer.material = materials[numberOfPlayers];

        GameObject spawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
        this.transform.position = spawnPos.transform.position;
        speed = baseSpeed;

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

    public void OnDash(InputAction.CallbackContext context)
    {
        Dash();
    }
    public void OnDownJump(InputAction.CallbackContext context)
    {

        DownJump();

    }
    private void FixedUpdate()
    {
        Move();
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
    private void Update()
    {
        var jump = playerInput.actions["Jump"];
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;//shouldnt modify rb.velocity directly,, use rb addforce instead?
        }

        else if (rb.linearVelocity.y > 0 && !jump.IsPressed())
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("not falling");
        }
    }
    void Jump()
    {

        Vector3 jumpForces = Vector3.zero;
        if(isGrounded)
        {
            //animator.SetBool("isJumping", true);
            jumpForces = Vector3.up * jumpForce;

        }

        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }

    void Dash()
    {
        if (isGrounded)
        {
            isDashing = !isDashing;
            if (isDashing == true)
            {
                speed = dashSpeed;
            }
            else
            {
                speed = baseSpeed;
            }
        }
    }
    void DownJump()
    {
        Vector3 jumpForces = Vector3.zero;
        if (!isGrounded)
        {

            jumpForces = Vector3.down * jumpForce;

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
