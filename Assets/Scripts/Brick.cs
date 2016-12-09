using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	 
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private LevelMenager levelMenager;
	private int timesHit;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
			print(breakableCount);
		}
		timesHit = 0;
		levelMenager = GameObject.FindObjectOfType<LevelMenager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if(isBreakable){
			
			HandleHits();
		}
	}
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			levelMenager.BrickDestroyed();
			GameObject smokeSmog = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
			smokeSmog.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
		}else{
			LoadSprites();
		}
	}
	void LoadSprites(){
		int spriteIndex = timesHit-1;
		if( hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("block sprite missing");
		}
		
	}
	//TODO Remove this method once we can actuallly win!
	void SimulateWin(){
		levelMenager.LoadNextLevel();
	}
}
