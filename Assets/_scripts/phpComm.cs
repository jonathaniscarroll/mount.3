using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class phpComm : MonoBehaviour
{
	private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
	public string addScoreURL = "https://mount.toughguymountain.com/php/addscore.php?"; //be sure to add a ? to your url
	public string grabScoreURL = "https://mount.toughguymountain.com/php/grabscore.php?";

	public game_engine GameEngine;
	public fbInit Facebook;

	private string userName;

	public static string download;
//	private string[] posts;
//	private int[] likes;

	public int firstLike;

	private Dictionary<string,float> newDick;

	public static Dictionary<string,string> messages;

	public static WWW serverResponse;

	void Start()
	{
		GameEngine = gameObject.GetComponent<game_engine> ();
		Facebook = gameObject.GetComponent<fbInit> ();
		newDick = new Dictionary<string,float> ();
	}

	public IEnumerator ServerConnection(string name, Dictionary<string, float> posts){

		yield return StartCoroutine (GrabScores (name));

		if (!string.IsNullOrEmpty (serverResponse.error)) {
			//log error from server, grabscores.php
			print ("error downloading scores: " + serverResponse.error + " " + serverResponse.text);
			yield break;
		}

		if (serverResponse.text.Length != 0) {
			//returning user
			string[] splitString = serverResponse.text.Split (new string[] {"</next>"},StringSplitOptions.None);
			int state = int.Parse(splitString[0]);
			newDick = compare.CompareDicks (splitString[1]);
		} else {
			//new user
			newDick = fbInit.facebookDict;
			addLikes.addDickLikes (newDick);
		}

		string stringDick = serializeInfo.Save (newDick);

		yield return StartCoroutine (PostScores (name, stringDick));

		if (!string.IsNullOrEmpty(serverResponse.error)) {
			print ("There was an error posting the high score: " + serverResponse.error);
		} else {
			Debug.Log ("It worked on this end");
		}

		Facebook.postContent ();
	}

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, string posts)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//Debug.Log("2." + name + " " + score);
		string hash = GameEngine.Md5Sum(name + posts + secretKey);

		string post_url = addScoreURL + "name=" + name + "&posts=" + posts + "&hash=" + hash;

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done

		serverResponse = hs_post;

//		Debug.Log (hs_post.text);

	}

	IEnumerator GrabScores(string name)
	{
		string hash = GameEngine.Md5Sum(name + secretKey);
		string post_url = grabScoreURL + "name=" + name + "&hash=" + hash;
//		Debug.Log (post_url);

		WWW grab = new WWW(post_url);
		yield return grab;
		serverResponse = grab;


	}

	public static void uploadMessages(List<string> newIds)
	{
		
	}

}