using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {


    private Transform moon;
    private Transform earth;
    private Rigidbody rbMoon;
    public float gravity = 25;



    public void Attract(Transform moon)
    {
        earth = transform;

        Vector3 direction = (moon.position - earth.position).normalized;
        Vector3 forward = moon.forward;
        Vector3 up = moon.up;
        

        Rigidbody rb = moon.GetComponent<Rigidbody>();

        //moon.LookAt(direction);

        rb.AddForce(direction, ForceMode.Force);
        rb.AddForce(up, ForceMode.Force);

        Vector3 line = earth.position - moon.position;
        line.Normalize();
        float distance = Vector3.Distance(earth.position + new Vector3(50,50,50), moon.position);
        Vector3 force = line * gravity / distance;

        rb.AddForce(force, ForceMode.Force);


        Quaternion targetRotation = Quaternion.FromToRotation(forward, direction) * moon.rotation;
        moon.rotation = Quaternion.Slerp(moon.rotation, targetRotation, 50f * Time.deltaTime);

    }

    public void Update()
    {

    }

}
