using UnityEngine;
using System.Collections;
using System.IO;

public class DataManager : MonoBehaviour {

	public GameObject[] upgrades;
	public GameObject[] items;
	public Click click;
	public GoldPerSec ss;
	string path = @"C:/Users/Anna/Documents/Incremental/Assets/datafile.txt";
	string path2 = @"C:/Users/Anna/Documents/Incremental/Assets/datafile2.txt";

	public void SaveTheData(){
		PlayerPrefs.SetFloat ("gold", click.gold);
		PlayerPrefs.SetFloat ("goldperclick", click.goldperclick);
		PlayerPrefs.SetFloat ("clickmult", click.clickMult);
		PlayerPrefs.SetInt ("gemcount", click.gems);
		PlayerPrefs.SetFloat ("gpsmult", ss.gpsMult);

		StreamWriter df = File.CreateText (path);
		for (int i = 0; i < upgrades.Length; i++) {
			string name = upgrades[i].GetComponent<UpgradeManager>().itemName;
			int count = upgrades[i].GetComponent<UpgradeManager> ().count;
			int cost = 	upgrades[i].GetComponent<UpgradeManager> ().cost;
			df.WriteLine(name + "," + count + "," + cost);
		} 
		df.Close ();

		StreamWriter df2 = File.CreateText (path2);
		for (int i = 0; i < items.Length; i++) {
			string name = items[i].GetComponent<ItemManager>().itemName;
			int count = items[i].GetComponent<ItemManager> ().count;
			int cost = 	items[i].GetComponent<ItemManager> ().cost;
			df2.WriteLine(name + "," + count + "," + cost);
		} 
		df2.Close ();
	}

	public void LoadTheData(){

		if (PlayerPrefs.GetFloat ("goldperclick") == 0) {
			click.goldperclick = 1;
		} else {
			click.gold = PlayerPrefs.GetFloat("gold");
			click.goldperclick = PlayerPrefs.GetFloat ("goldperclick");
			click.clickMult = PlayerPrefs.GetFloat("clickmult");
			click.gems = PlayerPrefs.GetInt("gemcount");
			ss.gpsMult = PlayerPrefs.GetFloat("gpsmult");
		}

		// Loads upgrades
		StreamReader rd = File.OpenText (path);
		string line;
		line = rd.ReadLine();
		int i = 0;
		while(line != null){
			string[] entry = line.Split(',');
			upgrades[i].GetComponent<UpgradeManager>().itemName = entry[0];
			upgrades[i].GetComponent<UpgradeManager>().count = int.Parse (entry[1]);
			upgrades[i].GetComponent<UpgradeManager>().cost = int.Parse (entry[2]);
			i++;
			line = rd.ReadLine();
		}
		rd.Close ();

		//Loads Items
		StreamReader rd2 = File.OpenText (path2);
		string line2;
		line2 = rd2.ReadLine();
		int i2 = 0;
		while(line2 != null){
			string[] entry2 = line2.Split(',');
			items[i2].GetComponent<ItemManager>().itemName = entry2[0];
			items[i2].GetComponent<ItemManager>().count = int.Parse (entry2[1]);
			items[i2].GetComponent<ItemManager>().cost = int.Parse (entry2[2]);
			i2++;
			line2 = rd2.ReadLine();
		}
		rd2.Close ();
	}
	
	public void ResetData(){
		PlayerPrefs.DeleteAll ();
		File.Delete (path);
		Application.LoadLevel (Application.loadedLevel);
	}
		
}



	


