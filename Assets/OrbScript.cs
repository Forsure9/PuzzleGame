using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbScript : MonoBehaviour {

	public int orbType;
	public int row;
	public int col;
	public bool marked;
	public bool working;

	public void Start(){
		working = true;
	}

	// Update is called once per frame
	public void UpdateColor () {
		if(orbType == 0){
			GetComponent<Image>().color = Color.red;
		}
		else if(orbType == 1){
			GetComponent<Image>().color = Color.green;
		}
		else if(orbType == 2){
			GetComponent<Image>().color = Color.blue;
		}
	}

	public void ChangeColor(){
		GameObject canvas = GameObject.Find("Canvas");
		GridManager gm = canvas.GetComponent<GridManager>();
		if (gm.turnCount < gm.maxTurns){

			gm.turnCount += 1;

			gm.orbArray[row, col].GetComponent<OrbScript>().orbType += 1;
			gm.orbArray[row, col].GetComponent<OrbScript>().orbType %= 3;
			gm.orbArray[row, col].GetComponent<OrbScript>().UpdateColor();

			if(row > 0){
				gm.orbArray[row-1, col].GetComponent<OrbScript>().orbType += 1;
				gm.orbArray[row-1, col].GetComponent<OrbScript>().orbType %= 3;
				gm.orbArray[row-1, col].GetComponent<OrbScript>().UpdateColor();
			}
			if(row < 4){
				gm.orbArray[row+1, col].GetComponent<OrbScript>().orbType += 1;
				gm.orbArray[row+1, col].GetComponent<OrbScript>().orbType %= 3;
				gm.orbArray[row+1, col].GetComponent<OrbScript>().UpdateColor();
			}
			if(col > 0){
				gm.orbArray[row, col-1].GetComponent<OrbScript>().orbType += 1;
				gm.orbArray[row, col-1].GetComponent<OrbScript>().orbType %= 3;
				gm.orbArray[row, col-1].GetComponent<OrbScript>().UpdateColor();
			}
			if(col < 4){
				gm.orbArray[row, col+1].GetComponent<OrbScript>().orbType += 1;
				gm.orbArray[row, col+1].GetComponent<OrbScript>().orbType %= 3;
				gm.orbArray[row, col+1].GetComponent<OrbScript>().UpdateColor();
			}
		}
		if(gm.turnCount == gm.maxTurns){
			gm.turnCount += 1;
			working = false;
			gm.clearingLines = true;
			gm.CheckForLines();

		}
	}
}
