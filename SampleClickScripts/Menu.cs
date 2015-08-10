using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void MoveMenu(){
		Vector2 pos = this.transform.position;
		if (pos.y < 50) {
			pos.y = 234.0f;
			iTween.MoveTo (gameObject, pos, 0.7f);
		} else {
			pos.y = 29.0f;
			iTween.MoveTo (gameObject, pos, 0.7f);				
		}
	
	}
}
