using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{   
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1;
    public float laneDistance = 4;//distance between two lanes
    public float jumpForce;
    public float Gravity = -50;
    public Animator animator;
    public bool isGrounded;
    //public LayerMask groundLayer;
    //public Transform groundCheck;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;
        if(forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f*Time.deltaTime;
        }
        animator.SetBool("isGameStarted",true);
        direction.z = forwardSpeed;
       // isGrounded = Physics.CheckSphere(groundCheck.position,0.15f,groundLayer);
        animator.SetBool("isGrounded",controller.isGrounded);
        if (controller.isGrounded)
        {
            //direction.y = 0;
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        //inputs
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane==3)
                desiredLane = 2;
            
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane==-1)
                desiredLane = 0;
        }

        //calculate where we should be 
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane==0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //transform.position = Vector3.Lerp(transform.position,targetPosition,800*Time.deltaTime);
        //controller.center = controller.center;
        if (transform.position != targetPosition)
        {
         Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude< diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);           
        }

        controller.Move(direction*Time.deltaTime);
    }

    private void Jump()
    {
        FindObjectOfType<AudioManager>().PlaySound("Jump");
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag=="Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

}
