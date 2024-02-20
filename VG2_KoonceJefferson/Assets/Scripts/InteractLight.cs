using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLight : MonoBehaviour
{
    // Start is called before the first frame update
    public void Interact()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
