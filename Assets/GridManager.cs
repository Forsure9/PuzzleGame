using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridManager : MonoBehaviour {
	public GameObject orb;
	public int GridSize;
	public GameObject[,] orbArray = new GameObject[5, 5];
	public int maxTurns;
	public int turnCount;

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

		for(int i=0; i<5; i++){
			for(int j=0; j<5; j++){

			}
		}

	}

}
