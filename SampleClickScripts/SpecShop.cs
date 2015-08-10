using UnityEngine;
using System.Collections;

public class SpecShop : MonoBehaviour {

	public UnityEngine.UI.Text gemsDisplay;
	public Click click;
	public GoldPerSec gps;
	public GameObject specWindow;
	public float clickMultInc;
	public float gpsMultInc;
	public int gemCost;

	void Update(){
		gemsDisplay.text = "Gems: " + click.gems;
	}

	public void OpenWindow(){
		specWindow.SetActive (true);
	}

	public void CloseWindow(){
		specWindow.SetActive (false);
	}

	public void IncreaseClickPower(){
		if (click.gems >= gemCost) {
			click.gems -= gemCost;
			click.clickMult += clickMultInc;
			gps.gpsMult += gpsMultInc;
			this.gameObject.SetActive (false);
		}
	}


}
