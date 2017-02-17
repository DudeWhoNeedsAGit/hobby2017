using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPerSec : MonoBehaviour {

	public ClickScript click;
	public UpgradeManager[] upgrades;


	void Start(){
		StartCoroutine(autoGold());
	}

	public float returnTickValue()
	{
		float tick = 0;

		foreach (UpgradeManager m in upgrades) {
			tick += m.goldPerSecond * m.count;
		}
		return tick;
	}

	public void autoGoldPerSec(){
		float returnValue = returnTickValue ();
		click.gold += returnValue / 10 ;// click.goldPerSecond;
		//gps.text = "GPS: " + returnValue ;
	}

	IEnumerator autoGold(){
		while (true) {
			autoGoldPerSec ();
			yield return new WaitForSeconds(0.1f);
		}
	}
}
