using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {


    private static ResourceManager instance;
    public float mass;
    public float massPoints;
    public float massSpawn;
    public float objectsDevoured;
    public float totalMass;
    public GameObject blackHole;
    public UnityEngine.UI.Text mps;


    public static ResourceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ResourceManager>();
            }
            return instance;
        }
    }

    // Use this for initialization
    public void Initialize (float mass, float massPoints, float objectsDevoured, float totalMass, float massSpawn) {

        this.mass = mass;
        this.massPoints = massPoints;
        this.objectsDevoured = objectsDevoured;
        this.totalMass = totalMass;
        this.massSpawn = massSpawn;
        blackHole.GetComponent<Rigidbody>().mass = mass;
    }

    // Update is called once per frame
    void Update () {

        mps.text = "MPS: " + massSpawn.ToString();

    }

    internal void updateMass(float critValue)
    {
        this.mass += critValue;
        this.massPoints += critValue;
        this.totalMass += critValue;
    }
}
