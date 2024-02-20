using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //State Tracking
    public List<int> keyIdsObtained;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        keyIdsObtained = new List<int>();
    }

    void Update()
    {
        Keyboard keyboardInput = Keyboard.current;
        Mouse mouseInput = Mouse.current;
        if(keyboardInput != null && mouseInput != null)
        {
            if (keyboardInput.eKey.wasPressedThisFrame)
            {
                Vector2 mousePosition = mouseInput.position.ReadValue();

                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 2f))
                {
                    print("Interacted with: " + hit.transform.name + " from " + hit.distance + "m.");

                    //Door interaction
                    Door targetDoor = hit.transform.GetComponent<Door>();
                    if (targetDoor)
                    {
                        targetDoor.Interact();
                    }

                    //Button interaction
                    InteractButton targetButton = hit.transform.GetComponent<InteractButton>();
                    if (targetButton)
                    {
                        targetButton.Interact();
                    }
                }
            }
        }
    }
}
