using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {


    public float gravity = -12;
   
	public void Attract(Transform body) 
	{

		Vector3 direction = (body.position - transform.position).normalized;
		Vector3 forward = body.forward;
        Rigidbody rb = body.GetComponent<Rigidbody>();

        body.LookAt(direction);

        rb.AddForce(direction * gravity, ForceMode.Force);

        Quaternion targetRotation = Quaternion.FromToRotation(forward,direction) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50f * Time.deltaTime );
        
    }


}