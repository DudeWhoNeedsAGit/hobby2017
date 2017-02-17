using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbar : MonoBehaviour {

    public ResourceManager rm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void buff()
    {
        StartCoroutine(increaseSpawnMass());
    }

    public IEnumerator increaseSpawnMass()
    {
        rm.massSpawn = rm.massSpawn + 5;

        yield return new WaitForSeconds(10.0f);

        rm.massSpawn = rm.massSpawn -5;
    }
}
