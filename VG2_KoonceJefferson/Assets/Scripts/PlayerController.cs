using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //State Tracking
    public List<int> keyIdsObtained;

    //Outlets
    public Transform povOrigin;
    public Transform projOrigin;
    public GameObject projPrefab;

    //Configuration
    public float attackRange;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        keyIdsObtained = new List<int>();
    }

    void OnPrimaryAttack()
    {
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(povOrigin.position, povOrigin.forward, out hit, attackRange);
        if (hitSomething)
        {
            Rigidbody targetRigidBody = hit.transform.GetComponent<Rigidbody>();
            if(targetRigidBody) targetRigidBody.AddForce(povOrigin.forward * 100f, ForceMode.Impulse);
        }
    }

    void OnSecondaryAttack()
    {
        GameObject projectile = Instantiate(projPrefab, projOrigin.position, Quaternion.LookRotation(povOrigin.forward));
        projectile.transform.localScale = Vector3.one * 5f;
        projectile.GetComponent<Rigidbody>().AddForce(povOrigin.forward * 25f, ForceMode.Impulse);
    }

    void OnInteract()
    {
        Mouse mouseInput = Mouse.current;
        Vector2 mousePosition = mouseInput.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
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
