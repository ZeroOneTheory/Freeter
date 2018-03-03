using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    Camera Cam;
    PlayerMotor motor;


	// Use this for initialization
	void Start () {
        Cam = Camera.main;
        motor = GetComponent<PlayerMotor>();


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, 100, movementMask))
            {
                // Move our player to what we hit
                Debug.Log("We hit " + hit.collider.name + hit.point);
                motor.MoveToPoint(hit.point);

                // Stop Focusing any Objects
            }
        }
	}
}
