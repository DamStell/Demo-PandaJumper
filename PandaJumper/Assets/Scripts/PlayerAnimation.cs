using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour

{
    private Animator animator;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;
    private Vector3 prevPos;
    private Vector3 actualPos;


 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        actualPos = GameObject.Find("Player").transform.position;

    }
    void Update()
    {


        //prevPos = GameObject.Find("Player").transform.position;
         
   
        //if(prevPos.x == actualPos.x)
        //{
        //    animator.SetBool("isRun", true);
        //}
        //if (prevPos.x != actualPos.x)
        //{
        //    animator.SetBool("isRun", true);
        //}


        //if (Input.GetButtonDown("Jump") )
        //{
        //    isJumping = true;
        //    jumpTimeCounter = jumpTime;
        //    animator.SetBool("isJump", true);
        //    animator.SetBool("isRun", false);

        //}


        //if (Input.GetButton("Jump") && isJumping == true)
        //{

        //    if (jumpTimeCounter > 0)
        //    {
              
        //        jumpTimeCounter -= Time.deltaTime;
        //        animator.SetBool("isJump", true);
        //        animator.SetBool("isRun", false);

        //    }
        //    else
        //    {
        //        isJumping = false;
        //        animator.SetBool("isJump", false);
        //    }


        //}
    }
}
