using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizVel;
    public int laneNum = 2;
    public bool controlLocked = false;
    [SerializeField] float goSpeed = 4;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(horizVel, 0, goSpeed);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && (laneNum > 1) && !controlLocked )
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (laneNum <3) && !controlLocked)
        {
            MoveRight();
        }



    }

    public void MoveLeft() 
    {
        horizVel = -5;
        StartCoroutine(stopSlide());
        laneNum -= 1;
        controlLocked = true;



    }

    public void MoveRight() 
    {
        horizVel = 5;
        StartCoroutine(stopSlide());
        laneNum += 1;
        controlLocked = true;
    }

    IEnumerator stopSlide() 
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = false;

    
    }
}
