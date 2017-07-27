using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class addLikes : MonoBehaviour {

	public game_engine GameEngine;
	public objectDictionary objDick;
	public compare compareScript;
	public static addLikes Instance;

	void Start () {
		GameEngine = gameObject.GetComponent<game_engine> ();
		objDick = gameObject.GetComponent<objectDictionary> ();
		compareScript = gameObject.GetComponent<compare> ();
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void addDickLikes(Dictionary<string, float> dick)
	{
		int likeCount = 0;
		int value;
		string data = "";
		foreach (KeyValuePair<string,float> post in dick) {
			value = (int)post.Value;
			data += "POST: " + post.Key + " LIKES: " + post.Value + " --- "; 
			likeCount+=value;
		}
//		Debug.Log (data);
		rawLikes.generateLikeTokens (likeCount);
//		Instance.GameEngine.likes = likeCount;
//		Instance.GameEngine.setText (likeCount);
//		Instance.objDick.populateCubicles (likeCount);

	}
}
