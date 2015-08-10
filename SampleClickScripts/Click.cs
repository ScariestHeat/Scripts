using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text gpc;
	public UnityEngine.UI.Text goldDisplay;
	public UnityEngine.UI.Text gemDisplay;
	public float gold = 0;
	public int gems = 0;
	public float goldperclick = 1;
	public float clickMult;

	void Update(){
		goldDisplay.text = "Gold: " + gold.ToString ("F0");
		gpc.text = goldperclick * clickMult + " gold/click";
		gemDisplay.text = "Gems: " + gems;
	}

	public void Clicked(){
		gold = gold + (goldperclick * clickMult);
		if ((Random.Range (0, 100)) > 50) {
			gems += 1;
		}
	}

}
