using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField]
    private float maxSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    // Sets rotation to 0 at the end of frame so the collisions aren't messed up
    private void LateUpdate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void HandleMovement()
    {
        transform.position += velocity;
    }

    private void HandleInput()
    {
        velocity.x = Input.GetAxis("Horizontal") * maxSpeed;
        velocity.z = Input.GetAxis("Vertical") * maxSpeed;
    }
}
