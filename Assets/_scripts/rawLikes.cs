using UnityEngine;
using System.Collections;

public class rawLikes : MonoBehaviour {

	public GameObject pubToken;

	public static GameObject token;

	// Use this for initialization
	void Start () {
		token = pubToken;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void generateLikeTokens(float newLikes){
		float quantity = newLikes / 10;
		Debug.Log ("LIKES: " + quantity);
		Vector3 pos;
		int value = (int)newLikes;
		GameObject thisToken;

		for (int i = 0; i < quantity; i++) {
			
			pos = new Vector3(Random.Range(-2f,2f),10,Random.Range(-2f,2f));
			thisToken = (GameObject)Instantiate (token, pos,  Quaternion.Euler (145, -45, 180));
			if (value <= 10) {
				thisToken.GetComponent<collectToken> ().tokenVal = value;
			} else {
				thisToken.GetComponent<collectToken> ().tokenVal = 10;
				value -= 10;
			}
		}
	}
}
