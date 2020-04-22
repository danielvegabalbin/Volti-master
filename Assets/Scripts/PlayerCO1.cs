using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCO1 : MonoBehaviour
{

    Rigidbody rigidbody;
    [SerializeField] GameObject disconnectionPanel;

    //CharacterController controller;
    //private Vector3 direction;

    [Header("Fordward Speed")]
    float forwardSpeed = 4;

    [Header("Current Lane")]
    public int desiredLane = 1; // 0 LEFT, 1 MIDDLE, 2 RIGHT

    [Header("On Wires Checker")]
    private bool onWires;

    [Header("Jump Force")]
    public float jumpForce;

    private float gravityScale = -4;

    public float[] laneX;

    Vector3 lane = new Vector3(0, 0, 0); // 0 izquierda, 1 medio, 2 derecha

    Vector3 leftLaneV = new Vector3(0,0,0);
    Vector3 middleLaneV = new Vector3(0, 0, 0);
    Vector3 rightLaneV = new Vector3(0, 0, 0);

    private void Awake()
    {
        //controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        disconnectionPanel.SetActive(false);
    }

    void Update()
    {
        
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

        leftLaneV = new Vector3(laneX[0], transform.position.y, transform.position.z);
        middleLaneV = new Vector3(laneX[1], transform.position.y, transform.position.z);
        rightLaneV = new Vector3(laneX[2], transform.position.y, transform.position.z);


        if (desiredLane == 1 && (transform.position.x == leftLaneV.x) ) // im in the left 
        {
            transform.position = Vector3.Lerp(leftLaneV, middleLaneV, 10);
        }
        if (desiredLane == 1 && (transform.position.x == rightLaneV.x)) // im in the right 
        {
            transform.position = Vector3.Lerp(rightLaneV, middleLaneV, 10);
        }

        if (desiredLane == 0 && (transform.position.x == middleLaneV.x)) // im in the middle to left 
        {
            transform.position = Vector3.Lerp(middleLaneV, leftLaneV, 10);
        }

        if (desiredLane == 2 && (transform.position.x == middleLaneV.x)) // im in the middle to right 
        {
            transform.position = Vector3.Lerp(middleLaneV, rightLaneV, 10);
        }


        #endregion

    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * forwardSpeed;

        if (!onWires)
        {
            rigidbody.velocity += Vector3.up * gravityScale;
        }
        else
        {
            rigidbody.velocity += Vector3.up * gravityScale * 0.01f; ;
        }
        
    }
    public void Jump()
    {
        if (onWires)
        {
            rigidbody.AddForce(0, jumpForce, transform.position.z, ForceMode.Impulse);
        }
       
    }
    public void MoveRight() 
    {
        desiredLane++;
    }
    public void MoveLeft()
    {
        desiredLane--;
    }

    public void SetSpeed( float modifier) 
    {
        forwardSpeed = 5.0f + modifier;
    
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

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wire")
        {
            onWires = true;
        }

        if (collision.gameObject.tag == "Base")
        {
            Time.timeScale = 0;
            disconnectionPanel.SetActive(true);
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
