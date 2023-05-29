using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;

    private float gravity = -20f;
    private Vector3 direction;
    public float speed = 8f;
    public float jumpforce = 8f;
    public float jumpTime;
    private float jumpTimeCounter;
    private float moveInput;
    private float moveInputjoystick;
    private bool jumpButtonClick = false;
    private bool jumpButtonHold = false;

    private int counterJump = 0;
    private Animator animator;
    private GameObject Panda;
    public Joystick joystick;

    private CharacterController characterController;
    // private Animator animator;

    private bool isGrounded;
    private bool isJumping;
    private Vector3 velocity;
    void Awake()
    {
        Panda = GameObject.Find("PandaCharacter1");
        animator = Panda.GetComponent<Animator>();
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
       // Panda = new GameObject("PandaCharacter1");
        //animator = Panda.GetComponent<Animator>();

     
    }

    private void FixedUpdate()
    {
        // movment 
        moveInput = Input.GetAxis("Horizontal");
        direction.x = moveInput * speed;
        moveInputjoystick = joystick.Horizontal;
        direction.x = moveInputjoystick * speed + moveInput * speed;
  


    }
    void Update()
    {

   

        if(moveInput>0 ||moveInputjoystick>0)
        {
            Vector3 rotation = GameObject.Find("PandaCharacter1").transform.eulerAngles;
            rotation.y = 90;
            GameObject.Find("PandaCharacter1").transform.eulerAngles = rotation;
           // transform.eulerAngles = new Vector3(0, 0, 0);

        }else if (moveInput<0 || moveInputjoystick<0) 
        {
            Vector3 rotation = GameObject.Find("PandaCharacter1").transform.eulerAngles;
            rotation.y = 270;
            GameObject.Find("PandaCharacter1").transform.eulerAngles = rotation;
            // transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (moveInput != 0)
        {
            animator.SetBool("isRun", true);
        }
        else if ( moveInput == 0)
        {
            animator.SetBool("isRun", false);
            if (moveInputjoystick != 0)
            {
                animator.SetBool("isRun", true);
            }
            else if (moveInputjoystick == 0)
            {
                animator.SetBool("isRun", false);
            }
        }



        //jump
        if ((Input.GetButtonDown("Jump")||jumpButtonClick) && isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            direction.y = jumpforce;
            animator.SetBool("isJump", true);
            animator.SetBool("isRun", false);


        }


        if ((Input.GetButton("Jump")||jumpButtonHold)&&isJumping==true )
        {
         
            if(jumpTimeCounter>0)
            {
                animator.SetBool("isJump", true);
                direction.y = jumpforce;
                jumpTimeCounter -= Time.deltaTime;
                
            }
            else
            {
                isJumping = false;
                animator.SetBool("isJump", false);
            }

           

        }
        if((!Input.GetButton("Jump")) && jumpButtonClick == false && jumpButtonHold == false)
        {
            animator.SetBool("isJump", false);
        } 

        if (direction.z!=0)
        {
            direction.z = 0;

        }
        // add gravity
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
        if( isGrounded && direction.y<0)
        {
            direction.y = 0;
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        characterController.Move(direction * Time.deltaTime);
        //if (characterController.velocity.)
        //{

        //    animator.SetBool("isRun", true);
        //}
        //else animator.SetBool("isRun", false);

        Vector3 pos = GameObject.Find("Player").transform.position;
        pos.z = 0;
        GameObject.Find("Player").transform.position = pos;

       



        //animator.SetFloat("speedJump", velocity.y);

    }

    public void JumpButton()
    {
        jumpButtonClick = true;

    }
    public void PressedJumpButton()
    {
    
        jumpButtonHold = true;
        jumpButtonClick = true;

    }
    public void JumpButtonNotPressed()
    {
        jumpButtonClick = false;
        jumpButtonHold= false;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Point"))
        {
            ScoreMenager.intance.AddPoint();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Portal"))
        {
          
            SceneManager.LoadScene("MainMenu");
        }

    }
}
