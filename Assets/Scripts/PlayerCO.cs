using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCO : MonoBehaviour
{

    CharacterController controller;
    private Vector3 direction;

    [Header ("Fordward Speed")]
    public float forwardSpeed;

    [Header("Current Lane")]
    public int desiredLane = 1; // 0 LEFT, 1 MIDDLE, 2 RIGHT

    float laneDistance = 3;

    [Header("On Wires Checker")]
    public bool onWires;

    [Header("Jump Force")]
    public float jumpForce;
    
    private float gravity = -20;
    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        #region Forward Movement
        direction.z = forwardSpeed;
        #endregion

        #region Input Checkers
        if (Input.GetKeyDown(KeyCode.Space) && onWires)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && desiredLane < 2) { MoveRight(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && desiredLane > -1) { MoveLeft(); }

        if (desiredLane > 2)
        {
            desiredLane = 2;
        }
        if (desiredLane < 0)
        {
            desiredLane = 0;
        }
        #endregion

        #region Side Movement
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        float transition = 20 * Time.deltaTime;

        //Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, 500);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 1);
        //transform.position = newPosition;


        #endregion



    }

    public void Jump()
    {
        direction.y = jumpForce;
    }

    private void FixedUpdate()
    {
        direction.x *= 5 * Time.deltaTime;
        direction.y += (gravity) * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
        
    }
    public void MoveRight() 
    {
        desiredLane++;
    }
    public void MoveLeft()
    {
        desiredLane--;
    }

    #region OnTriggers
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wire")
        {
            onWires = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wire")
        {
            onWires = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wire")
        {
            onWires = false;
        }
    }

    
    #endregion

    #region OnCollisions

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.point.z > transform.position.z + (controller.radius/2))
    //    {
    //        Debug.Log("ObstacleDetected");

    //    }
    //    if (hit.gameObject.tag == "Obstacle")
    //    {
    //        Debug.Log("ObstacleDetected");
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wire")
        {
            onWires = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Wire")
        {
            onWires = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Wire")
        {
            onWires = false;
        }
    }
    #endregion



}
