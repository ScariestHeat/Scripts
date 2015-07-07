using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public UnityEngine.UI.Text iteminfo;
	public Click click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	public Color standard;
	public Color affordable;
	private float baseCost;

	void Start(){
		baseCost = cost;
	}

	void Update(){
		iteminfo.text = itemName + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nGold: " + tickValue + "/s";
		if(click.gold >= cost) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image> ().color = standard;
		}
	}

	public void PurchasedItem(){
		if (click.gold >= cost) {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
		}


	}

}
