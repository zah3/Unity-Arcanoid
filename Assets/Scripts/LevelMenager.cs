using UnityEngine;
using System.Collections;

public class LevelMenager : MonoBehaviour {


	public void LoadLevel(string name){
		Debug.Log("Level load requested for "+ name);
		Application.LoadLevel(name);
	}
	public void Quit(){
		Debug.Log("I wont a quit");
		Application.Quit();
	}
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel ();
		}
	}
}
