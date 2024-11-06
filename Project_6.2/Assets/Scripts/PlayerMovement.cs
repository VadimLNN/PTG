using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [Range(1, 100)]
    public float playerSpeed;

    void Start() => controller = GetComponent<CharacterController>();

    void Update()
    {
        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        velocity = velocity.normalized * playerSpeed * Time.deltaTime;

        controller.Move(velocity);
    }
}
