using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public int keyid;

    void OnTriggerEnter(Collider other)
    {
        PlayerController target = other.GetComponent<PlayerController>();
        if (target != null)
        {
            target.keyIdsObtained.Add(keyid);
            Destroy(gameObject);
        }
    }
}
