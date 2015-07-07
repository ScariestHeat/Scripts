using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text gpc;
	public UnityEngine.UI.Text GoldDisplay;
	public float gold = 0.00f;
	public int goldperclick = 1;

	void Update(){
		GoldDisplay.text = "Gold: " + CurrencyConverter.Instance.GetCurrencyIntoString(gold, false, false);
		gpc.text = CurrencyConverter.Instance.GetCurrencyIntoString(goldperclick, false, true) + " gold/click";
	}

	public void Clicked(){
		gold += goldperclick;
	}

}