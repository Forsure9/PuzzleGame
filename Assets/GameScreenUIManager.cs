using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScreenUIManager : MonoBehaviour {

	void Start () {
		GameObject.Find("DungeonName").GetComponent<Text>().text = "Dungeon "+ globalData.dungeonSelected;

		Text cardText = GameObject.Find("cardText").GetComponent<Text>();
		cardText.text = "cards: ";

		for(int i=0; i<globalData.playerBattleInv.Count; i++){
			cardText.text += globalData.playerBattleInv[i] + ", ";
		}
	}
}
