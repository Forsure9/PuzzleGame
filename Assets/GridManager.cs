using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridManager : MonoBehaviour {
	public GameObject orb;
	public int GridSize;
	public GameObject[,] orbArray = new GameObject[5, 5];
	public int maxTurns;
	public int turnCount;

	public int totalRedCount = 0;
	public int totalGreenCount = 0;
	public int totalBlueCount = 0;

	// Use this for initialization
	void Start () {
		Transform canvas = GameObject.Find("Canvas").transform;
		for(float i=0.0f; i<(float)GridSize; i+=1.0f){
			for(float j=0.0f; j<(float)GridSize; j+=1.0f){
				GameObject orbClone = (GameObject)Instantiate(orb);
				orbClone.transform.SetParent(canvas, true);
				orbClone.transform.localScale = new Vector3(1.0f, 1.0f, 1);
				orbClone.transform.localPosition = new Vector3((i-2)*110, (j-5.0f)*110, 0);

				OrbScript os = orbClone.GetComponent<OrbScript>();
				os.orbType = Random.Range(0, 3);
				os.UpdateColor();
				os.row = (int)j;
				os.col = (int)i;
				orbArray[(int)j, (int)i] = orbClone;
			}
		}
	}

	public void CheckForLines(){
		int redCount = 0;
		int greenCount = 0;
		int blueCount = 0;

		for(int i=0; i<2; i++){
			for(int j=0; j<5; j++){
				OrbScript current = orbArray[i, j].GetComponent<OrbScript>();
				OrbScript next1 = orbArray[i+1, j].GetComponent<OrbScript>();
				OrbScript next2 = orbArray[i+2, j].GetComponent<OrbScript>();
				OrbScript next3 = orbArray[i+3, j].GetComponent<OrbScript>();


				if(current.orbType == next1.orbType && current.orbType == next2.orbType &&
					current.orbType == next3.orbType){
					current.GetComponent<Image>().color = Color.yellow;
					next1.GetComponent<Image>().color = Color.yellow;
					next2.GetComponent<Image>().color = Color.yellow;
					next3.GetComponent<Image>().color = Color.yellow;
					current.marked = true;
					next1.marked = true;
					next2.marked = true;
					next3.marked = true;
				}
			}
		}
		for(int i=0; i<5; i++){
			for(int j=0; j<2; j++){
				OrbScript current = orbArray[i, j].GetComponent<OrbScript>();
				OrbScript next1 = orbArray[i, j+1].GetComponent<OrbScript>();
				OrbScript next2 = orbArray[i, j+2].GetComponent<OrbScript>();
				OrbScript next3 = orbArray[i, j+3].GetComponent<OrbScript>();


				if(current.orbType == next1.orbType && current.orbType == next2.orbType &&
					current.orbType == next3.orbType){
					current.GetComponent<Image>().color = Color.yellow;
					next1.GetComponent<Image>().color = Color.yellow;
					next2.GetComponent<Image>().color = Color.yellow;
					next3.GetComponent<Image>().color = Color.yellow;
					current.marked = true;
					next1.marked = true;
					next2.marked = true;
					next3.marked = true;
				}
			}
		}
		for(int i=0; i<5; i++){
			for(int j=0; j<5; j++){
				OrbScript orb = orbArray[i, j].GetComponent<OrbScript>();
				if(orb.marked){
					if(orb.orbType == 0){
						redCount += 1;
					}
					else if(orb.orbType == 1){
						greenCount += 1;
					}
					else if(orb.orbType == 2){
						blueCount += 1;
					}
				}
			}
		}
		totalRedCount += redCount;
		totalGreenCount += greenCount;
		totalBlueCount += blueCount;

	}

}
