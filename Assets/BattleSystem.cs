using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {

	public bool isRunning;
	public float t;
	void Start () {
		isRunning = false;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(isRunning){
			GameObject.Find("BattleText").GetComponent<Text>().text = "Battle System [placeholder]";
			t += Time.deltaTime;
			if (t >= 1.5f){
				t = 0.0f;
				isRunning = false;
				GameObject.Find("BattleText").GetComponent<Text>().text = "";
				GridManager gm = GetComponent<GridManager>();

				if (gm.orbsToReplace > 0){
					gm.replacingOrbs = true;
				}
				else{
					gm.replacingOrbs = false;
					gm.turnCount = 0;
				}
			}
		}	
	}
}
