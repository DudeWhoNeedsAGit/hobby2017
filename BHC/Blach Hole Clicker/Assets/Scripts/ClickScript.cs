using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {

	public UnityEngine.UI.Text goldDisplay;
    public UnityEngine.UI.Text gpc;


	public float gold = 0.00f;	
	public float goldPerClick = 1;
	public float goldPerSecond;

	// Update is called once per frame
	void Update () {
		goldDisplay.text = "Gold: " + Mathf.Round(gold);
		gpc.text = "GPC: " + goldPerClick.ToString();
        

    }

    public void Clicked() {
	
        float critValue = goldPerClick;
        bool crit = true;

        if (Random.Range(1,10) % 2 == 0)
        {
            crit = false;
        }else
        {
            crit = true;
            critValue = critValue * Random.Range(2, 4);
        }
        StartCoroutine(CombatTextManager.Instance.createText(transform.position, transform.rotation,  critValue.ToString(), Color.red, crit));
        gold += critValue;
    }


}
