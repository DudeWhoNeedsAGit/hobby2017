using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Spawn : MonoBehaviour
{


    [SerializeField]
    private GameObject massBody;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float minSize, maxSize;
    public RectTransform canvasTransform;
    public GravityAttractor gravityAttractor;
    public ResourceManager rm;
    public float multipleSpawnInterval;


    private void Start()
    {
        StartCoroutine(SpawnMultipleObjects(multipleSpawnInterval));
    }


    void Update()
    {

        //Checks for Input

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
           StartCoroutine(SpawnObject(Input.mousePosition));

        

    }

    private IEnumerator SpawnMultipleObjects(float multipleSpawnInterval)
    {
        while(true)
        {
            for (int i = 0; i < rm.massSpawn; i++)
            {
                // would prop. be better to make it max on the resolution of the screen?
                StartCoroutine(SpawnObject(new Vector3(UnityEngine.Random.Range(5,1000), UnityEngine.Random.Range(5, 1000), UnityEngine.Random.Range(5, 1000))));
            }
            yield return new WaitForSeconds(multipleSpawnInterval);
        }

        
    }

    private IEnumerator SpawnObject(Vector3 spawnPoint)
    {

        //Spawns a massBody at the mouse pos
        Vector3 screenPoint = spawnPoint;
        
        // points never have a rotation
        Quaternion screenPointrotation = new Quaternion(0,0,0,0);
        
        GameObject x = Instantiate(massBody, screenPoint, transform.rotation) as GameObject;
        // add spawned object to canvas - makes it visible
        x.transform.SetParent(canvasTransform);
        x.GetComponent<GravityBody>().attractor = gravityAttractor;
        x.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);


        //Scales the massBody to a random scale
        float i = UnityEngine.Random.Range(1, 20);
        x.transform.localScale = new Vector3(i, i, i);
        x.GetComponent<Rigidbody>().mass = UnityEngine.Random.Range(1,5);

        yield return null;

    }
}