using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float jumpHeight;

    [Header("Sounds")]
    [SerializeField] private AudioClip footsteps;
    AudioSource audioSource;
    public bool isMoving;
    private Vector3 moveDirection;
    private Vector3 velocity;

    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();


        if (!audioSource.isPlaying) audioSource.PlayOneShot(footsteps, 0.1f);
        if (!isMoving) audioSource.Stop();
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        
        moveDirection = new Vector3(0,0,moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Jump();
            }
        }
        transform.Rotate(0, Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
    
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        if (!audioSource.isPlaying) audioSource.PlayOneShot(footsteps, 0.1f);
        if (!isMoving) audioSource.Stop();
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 2f,0.1f,Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("Jump");
    }
}
