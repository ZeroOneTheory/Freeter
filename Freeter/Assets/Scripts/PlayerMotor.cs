using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent; // Refrence to our Agent
    Transform Target; // Target to Follow

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

    // USe this to update target positions --- Change to CoRoutine
    void Update()
    {
        if (Target != null)
        {
            agent.SetDestination(Target.position); // Set the agents destination to our target
            FaceTarget();
        }  
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        Target = newTarget.interactionTransform;
    }
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        Target = null;
        
    }
    public void FaceTarget() // Very Math heavy! Research this more
    {
        /* https://www.youtube.com/watch?v=wXI9_olSrqo */ 

        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);


    }
}
