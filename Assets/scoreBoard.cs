using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour {

	private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
	public string dlScores = "https://mount.toughguymountain.com/php/leaderboard.php?"; //be sure to add a ? to your url
	private WWW grab;
	public ScrollRect scrollPanel;



	// Use this for initialization
	void Start () {
		
	}

	public void leaderBoardButton(){
		StartCoroutine(populateLeaderBoard());
	}
		
	
	public IEnumerator downloadLeaderBoard(){
		string hash = GetComponent<game_engine> ().Md5Sum (secretKey);
		string post_url = dlScores + "hash=" + hash;

		grab = new WWW(post_url);
		yield return grab;

	}

	public IEnumerator populateLeaderBoard(){
		yield return StartCoroutine (downloadLeaderBoard());

		Dictionary<string,int> scores = new Dictionary<string,int> ();
		string lbText = "";
		if (!string.IsNullOrEmpty (grab.error)) {
			//log error from server, grabscores.php
			print ("error downloading scores: " + grab.error + " " + grab.text);
		} else {
			string[] splitString = grab.text.Split (new string[] {"</next>"},StringSplitOptions.None);
			Debug.Log (splitString.Length);
			foreach (string split in splitString) {
				string[] newSplit = split.Split (new string[] { "</and>" }, StringSplitOptions.None);
//				scores.Add (newSplit[0],newSplit[1]);
				lbText += newSplit[0] + ": " + newSplit[1];
				Debug.Log(lbText);
			}
			scrollPanel.enabled = true;
			scrollPanel.content.GetComponent<Text> ().text = lbText;
		}
	}
}
