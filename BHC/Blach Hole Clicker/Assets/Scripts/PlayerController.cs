using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    private ClickScript clickScript;
    private ResourceManager resourcemanager;

    private Vector3 moveDirection;

	void Update () 
	{
        		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        //moveDirection = new Vector3(Random.Range(1, 5), 0, Input.GetAxisRaw("Vertical")).normalized;

    }

    private void Start()
    {
        clickScript = GameObject.FindObjectOfType<ClickScript>();
        resourcemanager = GameObject.FindObjectOfType<ResourceManager>();

    }

    void FixedUpdate () 
	{
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = (Rigidbody) other.GetComponent<Rigidbody>();
        Debug.Log(rb.mass);
        
        float critValue = clickScript.goldPerClick;
        bool crit = true;

        if (Random.Range(1, 10) % 2 == 0)
        {
            crit = false;
        }
        else
        {
            crit = true;
            critValue = critValue * Random.Range(2, 4);
        }
        StartCoroutine(CombatTextManager.Instance.createText(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, critValue.ToString(), Color.red, crit));
        clickScript.gold += critValue;

        resourcemanager.updateMass(critValue);

        

        resourcemanager.objectsDevoured += 1;


        /*
         * before we destroy the object
         * 1. Add mass (like +gold)
         * 2. Popup Text
         *
         **/


        DestroyObject(gameObject);
    }
}