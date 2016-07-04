using UnityEngine;
using System.Collections;
using System.Collections.Generic; //allows using lists

//FIGURE OUT SPECIFIC DOUBLE TAP DIRECTION FOR AXIS INPUTS

public class playerMovement : MonoBehaviour {

    //MOVEMENT VARIABLES
    Vector3 moveDirection = Vector3.zero; 	//aka Vector3(0,0,0);
    public float speed = 5.0f;
    public float turnSpeed = 2.5f;
    public Transform animBase;
    Rigidbody2D mainRigidBody;
    shaftPaddle animBasePaddle;

    float doubleTapCooler = 0.2f;
    float doubleTapTimer = 0.0f;
    public string singleTappedKey = "";

    public float angle;

    public bool player2 = false;

    public List<shaftPaddle> joints = new List<shaftPaddle>(new shaftPaddle[0]); //checks score difference, must be same size as in gameManager

    // Use this for initialization
    void Start () {
        mainRigidBody = animBase.GetComponent<Rigidbody2D>();
        animBasePaddle = animBase.GetComponent<shaftPaddle>();
    }
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetAxis("Vertical") != 0)
        {

        }
        mainRigidBody.velocity = moveDirection;

        if (!player2)
            moveDirection = new Vector3(0, Input.GetAxis("Vertical"), 0); //allows input from axes
        else
            moveDirection = new Vector3(0, Input.GetAxis("Vertical2"), 0); //allows input from axes
        moveDirection = transform.TransformDirection(moveDirection); //tells it how to move
        moveDirection.x *= (speed); //how fast to move
        moveDirection.y *= (speed); //how fast to move

        if (Input.GetKeyDown("e"))
        {
            for (int i = 0; i < joints.Count; i++)
            {
                joints[i].GetHard();
            }
        }
        else
        {
            if (!player2)
                mainRigidBody.angularVelocity = Input.GetAxis("Horizontal") * -turnSpeed;
            else
                mainRigidBody.angularVelocity = Input.GetAxis("Horizontal2") * -turnSpeed;
        }

        //DOUBLE TAPPING CODE
        //timer
        if (doubleTapTimer > 0)
        {
            doubleTapTimer -= 1 * Time.deltaTime;
        }
        else
            singleTappedKey = "";


        if (player2)
        {
            if (Input.GetKeyDown("down"))
                doubleTapCheck("down");
            if (Input.GetKeyDown("up"))
                doubleTapCheck("up");
            if (Input.GetKeyDown("left"))
                doubleTapCheck("left");
            if (Input.GetKeyDown("right"))
                doubleTapCheck("right");
        }
        else
        {
            if (Input.GetKeyDown("s"))
                doubleTapCheck("s");
            if (Input.GetKeyDown("w"))
                doubleTapCheck("w");
            if (Input.GetKeyDown("a"))
                doubleTapCheck("a");
            if (Input.GetKeyDown("d"))
                doubleTapCheck("d");
        }


        //if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
    }


    public void doubleTapCheck(string keyPressed)
    {
        
        if (doubleTapCooler > 0 && keyPressed == singleTappedKey) //Double Tap is true
        {
            //print("double tap");
            if (keyPressed == "down" || keyPressed == "s") //Rotate Down
            {
                for (int i = 0; i < joints.Count; i++)
                {
                    joints[i].GetHard(90.0f);
                }
            }

            if (keyPressed == "right" || keyPressed == "d") //Rotate Down
            {
                for (int i = 0; i < joints.Count; i++)
                {
                    joints[i].GetHard(180.0f);
                }
            }

            if (keyPressed == "left" || keyPressed == "a") //Rotate Down
            {
                for (int i = 0; i < joints.Count; i++)
                {
                    joints[i].GetHard(0.0f);
                }
            }

            if (keyPressed == "up" || keyPressed == "w") //Rotate Down
            {
                for (int i = 0; i < joints.Count; i++)
                {
                    joints[i].GetHard(270.0f);
                }
            }

            doubleTapTimer = 0.0f;
        }
        else
        {
            singleTappedKey = keyPressed;
            doubleTapTimer = doubleTapCooler;
        }
        

    }
}
