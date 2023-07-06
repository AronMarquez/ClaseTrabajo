using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion starRotation;

    public float swayAmount = 8;


    void Start()
    {
        starRotation = transform.localRotation;
        
    }


    void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float mouseX = Input.GetAxis("Mouse X");

        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);

        Quaternion yAngle = Quaternion.AngleAxis(mouseY * 1.25f, Vector3.left);

        Quaternion targerRotation = starRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targerRotation, Time.deltaTime * swayAmount);

    }

}
