using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardSelectorUIManager : MonoBehaviour {

	public GameObject cardButton;
	void Start () {
		int y=0;
		int x=0;
		Transform canvas = GameObject.Find("Canvas").transform;
		for (int i=0; i<30; i++){
			y = i/5;
			x = i%5;
			int id = globalData.playerTotalInv[i, 0];
			GameObject cardB = (GameObject)Instantiate(cardButton);
			cardB.transform.SetParent(canvas, true);
			cardB.transform.localScale = new Vector3(1.0f, 1.0f, 1);
			cardB.transform.localPosition = new Vector3((x*45.0f)-90.0f, (y*45.0f)-65.0f, 0);
			cardB.GetComponent<CardButtonScript>().cardId = i;

		}
	}
}
