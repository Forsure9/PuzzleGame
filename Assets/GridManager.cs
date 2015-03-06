using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridManager : MonoBehaviour {
	public GameObject orb;
	public int GridSize;
	public GameObject[,] orbArray;
	public int maxTurns;
	public int turnCount;

	public int totalRedCount;
	public int totalGreenCount;
	public int totalBlueCount;

	public bool clearingLines;
	public bool replacingOrbs;

	public int[][] markedOrbs;
	public int markedOrbIndex;

	public int orbsToClear;
	public int orbsToReplace;

	public float t;

	// Use this for initialization
	void Start () {
		orbArray = new GameObject[5, 5];
		clearingLines = false;
		replacingOrbs = false;
		t = 0;
		totalRedCount = 0;
		totalGreenCount = 0;
		totalBlueCount = 0;

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
					current.marked = true;
					next1.marked = true;
					next2.marked = true;
					next3.marked = true;
					markedOrbs[markedOrbIndex] = new int[2]{i, j};
					markedOrbs[markedOrbIndex+1] = new int[2]{i+1, j};
					markedOrbs[markedOrbIndex+2] = new int[2]{i+2, j};
					markedOrbs[markedOrbIndex+3] = new int[2]{i+3, j};
					markedOrbIndex += 4;
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
					current.marked = true;
					next1.marked = true;
					next2.marked = true;
					next3.marked = true;
					markedOrbs[markedOrbIndex] = new int[2]{i, j};
					markedOrbs[markedOrbIndex+1] = new int[2]{i, j+1};
					markedOrbs[markedOrbIndex+2] = new int[2]{i, j+2};
					markedOrbs[markedOrbIndex+3] = new int[2]{i, j+3};
					markedOrbIndex += 4;
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

		orbsToClear = redCount + greenCount + blueCount;

		GameObject.Find("RedScore").GetComponent<Text>().text = "Red: "+ totalRedCount;
		GameObject.Find("GreenScore").GetComponent<Text>().text = "Green: "+ totalGreenCount;
		GameObject.Find("BlueScore").GetComponent<Text>().text = "Blue: "+ totalBlueCount;
	}


	void Update(){
		if (clearingLines && orbsToClear > 0){
			for (int i=0; markedOrbs[i] != null; i++){
				if (markedOrbs[i] == null){
					continue;
				}
				int a = markedOrbs[i][0];
				int b = markedOrbs[i][1];
				t += Time.deltaTime/4.0f;
				if (orbArray[a, b]){
					OrbScript orb = orbArray[a, b].GetComponent<OrbScript>();
					Color original = orb.GetOrbColor();
					orb.GetComponent<Image>().color = Color.Lerp(original, Color.white, t);
					Color current = orb.GetComponent<Image>().color;
					if(current == Color.white){
						orb.orbType = Random.Range(0, 3);
						orbsToClear -= 1;
						orbsToReplace += 1;
					}
				}
			}
		}
		if (clearingLines && orbsToClear <= 0){
			clearingLines = false;
			if (orbsToClear == 0){
				replacingOrbs = false;
			}
			else{
				replacingOrbs = true;
			}
			orbsToClear = 0;
			t = 0;
		}
		if(replacingOrbs && orbsToReplace <= 0){
			replacingOrbs = false;
			orbsToReplace = 0;

			// call to battle system here
			// set turnCount=0 there and remove it from here
			// also make a bool that says whether the battle system is running
			// so that you can make an if statement here to make sure its called
			// only once, not every update
			turnCount = 0;
		}
		if (replacingOrbs && orbsToReplace > 0){
			for (int i=0; markedOrbs[i] != null; i++){
				if (markedOrbs[i] == null){
					continue;
				}
				int a = markedOrbs[i][0];
				int b = markedOrbs[i][1];
				t += Time.deltaTime/4.0f;
				if (orbArray[a, b]){
					OrbScript orb = orbArray[a, b].GetComponent<OrbScript>();
					Color original = orb.GetOrbColor();
					orb.GetComponent<Image>().color = Color.Lerp(Color.white, original, t);
					Color current = orb.GetComponent<Image>().color;
					if(current == original){
						orbsToReplace -= 1;
					}
				}
			}

		}
	}
}
