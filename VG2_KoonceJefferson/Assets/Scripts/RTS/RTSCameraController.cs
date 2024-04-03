using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RTSCameraController : MonoBehaviour
{
    // Config
    public float moveSpeed;

    // State Tracking
    Vector3 movement;

    //methods
    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        movement = new Vector3(direction.x, 0, direction.y);
    }

    void Update()
    {
        Vector3 checkPos = transform.position + movement * moveSpeed * moveSpeed * Time.deltaTime;
        checkPos += new Vector3(0, 10f, 0);

        bool onGround = Physics.Raycast(checkPos, Vector3.down, Mathf.Infinity, LayerMask.GetMask("Ground"));

        if (onGround) transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
