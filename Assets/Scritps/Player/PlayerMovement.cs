using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;




    void Update()
    {

        float X = Input.GetAxis("Horizontal");

        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;

        characterController.Move(move * speed * Time.deltaTime);

    }
}
