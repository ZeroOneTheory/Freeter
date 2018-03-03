using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Controls the players, by using the mouse to set a focus and moving towards that position */


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask; // Filter out everything that isnt walkable
    public Interactable Focus; // Players Current Focus

    Camera Cam; // refrence to ous Camera 
    PlayerMotor motor;  // Refrence to our Motor 


	// Getting Refrences
	void Start () {
        Cam = Camera.main;
        motor = GetComponent<PlayerMotor>();


	}
	
	// Update is called once per frame
	void Update () {

        // if Left mouse is pressed
        if (Input.GetMouseButtonDown(0)) //--------------- Movement
        {

            //Create Ray 
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If the Ray hits
            if (Physics.Raycast(ray,out hit, 100, movementMask))
            {
             // Move our player to what we hit
             motor.MoveToPoint(hit.point);

             RemoveFocus(); // Unfocus on object(s)
            }
        }
        // if Right mouse is pressed
        if (Input.GetMouseButtonDown(1)) // ------------ Interactions
        {
            //Create Ray 
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If the Ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus!= Focus)
        {
            if(Focus!=null)
                Focus.OnDeFocused();

            Focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocus(transform);
        

    }
    void RemoveFocus()
    {
        if (Focus != null)
            Focus.OnDeFocused();

        Focus = null;
        motor.StopFollowingTarget();
    }
}
