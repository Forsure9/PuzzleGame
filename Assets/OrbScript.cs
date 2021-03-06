﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbScript : MonoBehaviour {

	public int orbType;
	public int row;
	public int col;
	public bool marked;


	public Color GetOrbColor(){
		if(orbType == 0){
			return Color.red;
		}
		else if(orbType == 1){
			return Color.green;
		}
		else if(orbType == 2){
			return Color.blue;
		}
		else{
			return Color.white;
		}
	}

	public void UpdateColor () {
		GetComponent<Image>().color = GetOrbColor();
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
			gm.CheckForLines();

		}
	}
}
