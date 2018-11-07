using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rigidBody;
    float turningCenterDistance = 5;
    public float backWheelDistance = 1;

    // Use this for initialization
    void Start()
    {
        //gets the object associated with our Player
        rigidBody = GetComponent<Rigidbody>();
        //rigidBody.constraints = RigidbodyConstraints.FreezeRotationX; //| RigidbodyConstraints.FreezeRotationZ;
        //rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        //rigidBody.transform.localPosition = Vector3.zero;
        //this.transform.parent = rigidBody.transform;
        //this.transform.localPosition = new Vector3(0, 0, backWheelDistance);
    }
	
	// Update is called once per frame
	void Update () {

	}

    // Called every physics step
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //rigidBody.transform.position += movement;

        this.rigidBody.AddForce(new Vector3(-moveHorizontal*speed, 0, speed * -moveVertical));

        //rigidBody.MoveRotation(new Quaternion(moveHorizontal));

        if (Input.GetKey("left"))
        {
            Vector3 turningPivotPoint = rigidBody.transform.TransformPoint(new Vector3(-turningCenterDistance, 0, 0));
            rigidBody.transform.RotateAround(turningPivotPoint, -Vector3.up, 20 * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            Vector3 turningPivotPoint = rigidBody.transform.TransformPoint(new Vector3(turningCenterDistance, 0, 0));
            rigidBody.transform.RotateAround(turningPivotPoint, Vector3.up, 20 * Time.deltaTime);
        }

    }
}
