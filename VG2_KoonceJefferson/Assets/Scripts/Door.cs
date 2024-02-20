using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    public GameObject requiredSender;
    public int keyIdRequired = -1;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact(GameObject sender = null)
    {
        bool shouldOpen = false;

        //check button required
        if (!requiredSender)
        {
            shouldOpen = true;
        } else if (requiredSender == sender) {
            shouldOpen = true;
        }

        //check key required
        bool keyRequired = keyIdRequired >= 0;
        bool keyMissing = !PlayerController.instance.keyIdsObtained.Contains(keyIdRequired);
        if (keyRequired && keyMissing) shouldOpen = false;

        if(shouldOpen) animator.SetTrigger("Open");
    }
}
