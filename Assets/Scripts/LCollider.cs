using UnityEngine;
using System.Collections;

public class LCollider : MonoBehaviour {

	private LevelMenager levelMenager;
	
	void OnTriggerEnter2D (Collider2D trigger){
		levelMenager = GameObject.FindObjectOfType<LevelMenager>();
		levelMenager.LoadLevel("Lose");
	}
	void OnCollisionEnter2D (Collision2D collision){
		//print ("Collision");
	}
}
