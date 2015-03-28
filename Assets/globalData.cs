using UnityEngine;
using System.Collections;

public class globalData : MonoBehaviour {
	public static int[,] playerTotalInv = new int[30,2];
	public static ArrayList playerBattleInv = new ArrayList(5);
	public static int dungeonSelected = 1;
	public static int dungeonsUnlocked = 1;
	public static int[] enemyBattleInv = new int[5];

	//card data
	public static string[] name;
	public static int[] health;
	public static int[] defence;
	public static int[] attack;
	public static float[] healthMult;
	public static float[] defenceMult;
	public static float[] attackMult;
	public static int[] rank;
	public static int[] color;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	public void setDungeon(int d){
		dungeonSelected = d;
	}
}
