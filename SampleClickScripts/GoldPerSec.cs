using UnityEngine;
using System.Collections;

public class GoldPerSec : MonoBehaviour {

	public UnityEngine.UI.Text gpsDisplay;
	public Click click;
	public ItemManager[] itemArray;
	public float gpsMult = 1.00f;

	void Start(){
		StartCoroutine (AutoTick ());
	}

	void Update(){
		gpsDisplay.text = GetGoldPerSec () * gpsMult + " gold/sec";
	}

	public float GetGoldPerSec(){
		int tick = 0;
		foreach (ItemManager item in itemArray) {
			tick += item.count * item.tickValue;		
		}
		return tick;
	}

	public void AutoGoldPerSec(){
		click.gold += (GetGoldPerSec () / 10) * gpsMult;
	}

	IEnumerator AutoTick(){
		while (true) {
			AutoGoldPerSec();
			yield return new WaitForSeconds(0.10f);
		}
	}
}
 