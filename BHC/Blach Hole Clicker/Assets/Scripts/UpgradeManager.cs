using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	public UnityEngine.UI.Text iteminfo;
	public UnityEngine.UI.Text gps;

	public ClickScript click;
	public GoldPerSec goldPerSec;

	public float count = 0;
	public float clickPower;
	public string itemName;
	public float baseCost = 0;
	public float cost;
	public float baseGoldPerSecond = 0;
	public float goldPerSecond;


	void Start() {
		// initially no cost reduction
		cost = baseCost;
		goldPerSecond = baseGoldPerSecond;

	}

	void  Update() {
		iteminfo.text = itemName + "\n Cost:" + cost + "\n Power" + clickPower;
		gps.text = "GPS: " + goldPerSec.returnTickValue().ToString();

	}

	public void PurchasedUpgrade() {
		if (click.gold >= cost) {
			
			click.gold -= cost;
			count += 1;
			click.goldPerClick += clickPower;
			click.goldPerSecond += goldPerSecond;

			// calc new cost/gps values
			cost = Mathf.Round(baseCost * Mathf.Pow (1.35f, count));
			goldPerSecond = Mathf.Round(goldPerSecond * Mathf.Pow (1.001f, count));
		}
	
	}


}
