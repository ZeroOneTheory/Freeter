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
        if (Input.GetMouseButtonDown(0)) //--------------- Movement
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, 100, movementMask))
            {
             // Move our player to what we hit
             motor.MoveToPoint(hit.point);
                // Stop Focusing any Objects
            }
        }

        if (Input.GetMouseButtonDown(1)) // ------------ Interactions
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit interactable 
                // if we did set it as our focus
            }
        }
    }
}
