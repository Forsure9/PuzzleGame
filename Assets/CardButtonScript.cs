using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardButtonScript : MonoBehaviour {

	public int cardId;
	public bool isInBattleInv;
	public void SelectCard () {
		if (!isInBattleInv){
			if (globalData.playerBattleInv.Count < 5){
				globalData.playerBattleInv.Add(cardId);
				isInBattleInv = true;
				GetComponent<Image>().color = Color.green;

				
			}
		}
		else{
			globalData.playerBattleInv.Remove(cardId);
			isInBattleInv = false;
			GetComponent<Image>().color = Color.white;
		}
	}
}
