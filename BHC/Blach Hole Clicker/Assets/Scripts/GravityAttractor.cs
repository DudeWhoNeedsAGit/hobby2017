using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

	public float gravity = -12;

	public void Attract(Transform body) 
	{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 localUp = body.up;
        float dist = Vector3.Distance(body.position, transform.position);

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
        //body.GetComponent<Rigidbody>().AddForce((gravityUp * gravity) / Mathf.Pow(dist,2));

        Quaternion targetRotation = Quaternion.FromToRotation(localUp,gravityUp) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50f * Time.deltaTime );
        
    }
}