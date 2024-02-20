using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    //Configuration
    public GameObject interactionTarget;

    public void Interact()
    {
        if (interactionTarget != null)
        {
            //Doors
            Door targetDoor = interactionTarget.GetComponent<Door>();
            if (targetDoor != null)
            {
                print("Interacting with your door!");
                targetDoor.Interact(gameObject);
            }

            //Lights
            InteractLight targetLight = interactionTarget.GetComponent<InteractLight>();
            if (targetLight != null)
            {
                print("Interacting with your door!");
                targetLight.Interact();
            }
        }
    }
}
