using UnityEngine;
using System.Collections;

public class collectToken : MonoBehaviour {
	public static game_engine GameEngine;
	public int tokenVal;
	public GameObject text;

	private int speed;

	private GameObject scoreText;
	private bool die;

	void OnTriggerEnter(Collider other){
		if (other.gameObject == scoreText) {
			game_engine.likes += tokenVal;
			game_engine.setText (game_engine.likes);
			Destroy (gameObject);
			Debug.Log ("Gathered Like");
		}
		GameObject intern;
		if(other.gameObject.name == "intern"){
			intern = other.gameObject;
			showCount (tokenVal);
			intern.GetComponent<InternState> ().stateState ("collecting a like token!");
			intern.GetComponent<internMove> ().action = true;
		}
	}

	void Start(){
		GameEngine = GameObject.FindGameObjectWithTag("GameController").GetComponent<game_engine>();
//		Debug.Log (tokenVal);
		scoreText = GameObject.Find ("scoreText");
//		Debug.Log (scoreText);
		die = false;
		speed = 10;
	}

	void OnMouseOver(){
		
		if(Input.GetMouseButtonDown(0)){
			showCount(tokenVal);

		}
	}

	void Update(){
		if (die == true) {
			transform.position = Vector3.MoveTowards (transform.position, scoreText.transform.position,Time.deltaTime * speed);
		}
	}

	

	void showCount(int val){
		GameObject count = (GameObject)Instantiate (text, transform.position, Quaternion.Euler(60, -45, 0),gameObject.transform) as GameObject;
		TextMesh t = count.GetComponent<TextMesh> ();
		Color c = t.color;
		t.text = val.ToString();
		GetComponent<Rigidbody> ().isKinematic = true;
		die = true;
	}


}
