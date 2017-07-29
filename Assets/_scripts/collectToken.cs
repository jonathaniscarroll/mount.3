using UnityEngine;
using System.Collections;

public class collectToken : MonoBehaviour {
	public static game_engine GameEngine;
	public int tokenVal;
	public GameObject text;

	private int speed;

	private GameObject scoreText;
	private bool die;

	void Start(){
		GameEngine = GameObject.FindGameObjectWithTag("GameController").GetComponent<game_engine>();
		Debug.Log (tokenVal);
		scoreText = GameObject.Find ("scoreText");
		Debug.Log (scoreText);
		die = false;
		speed = 10;
	}

	void OnMouseOver(){
		
		if(Input.GetMouseButtonDown(0)){
			showCount(tokenVal);
			GetComponent<Rigidbody> ().isKinematic = true;
			die = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == scoreText) {
			GameEngine.setText (GameEngine.likes + tokenVal);
			Destroy (gameObject);
		}
	}

	void Update(){
		if (die == true) {
			transform.position = Vector3.MoveTowards (transform.position, scoreText.transform.position,Time.deltaTime * speed);
		}
	}

//	IEnumerator showCount(int val){
//		GameObject count = (GameObject)Instantiate (text, transform.position, Quaternion.EulerAngles (Vector3 (60, -45, 0)));
//		count.transform.Translate (Vector3.up * Time.deltaTime);
//
//	}

	void showCount(int val){
		GameObject count = (GameObject)Instantiate (text, transform.position, Quaternion.Euler(60, -45, 0),gameObject.transform) as GameObject;
		TextMesh t = count.GetComponent<TextMesh> ();
		Color c = t.color;
		t.text = val.ToString();

//		count.transform.Translate (Vector3.up * Time.deltaTime);
//		for (int i = 0; i < 100; i++) {
//			c.a -= 0.01f;
//		}
//		if (c.a == 0) {
//			Destroy(count);
//		}
	}


}
