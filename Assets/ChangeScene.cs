using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	public int dungeon;
	public void ChangeToScene (string sceneName) {
		Application.LoadLevel(sceneName);
	}
	public void setDungeon(int d){
		dungeon = d;
	}
}
