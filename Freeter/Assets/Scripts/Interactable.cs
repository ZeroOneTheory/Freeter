using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;
    public bool isFocused = false;
    bool hasInteracted = false;

    public virtual void Interact()
    {
        // this method is meant to be overwritten
        Debug.Log("Interacting with Object " + transform.name);
    }

    Transform Player;

    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float Distance = Vector3.Distance(Player.position, interactionTransform.position);
            if(Distance <= radius)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocus(Transform playersTransform)
    {
        isFocused = true;
        hasInteracted = false;
        Player = playersTransform;
    }
    public void OnDeFocused()
    {
        isFocused = false;
        hasInteracted = false;
        Player = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
