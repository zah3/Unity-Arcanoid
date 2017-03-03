using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}
	
	}
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(2f,this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x,1.26f, 14.76f); 
		this.transform.position = paddlePos;
	}
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(2f,this.transform.position.y, 0f);
		float mausePosInBox = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mausePosInBox,1.26f, 14.76f); 
		this.transform.position = paddlePos;
	}
}
