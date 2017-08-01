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

	public int firstLike;

	private Dictionary<string,float> postDick;

	public static WWW serverResponse;

	void Start()
	{
		GameEngine = gameObject.GetComponent<game_engine> ();
		Facebook = gameObject.GetComponent<fbInit> ();
		postDick = new Dictionary<string,float> ();
	}

	public IEnumerator ServerConnection(string name, Dictionary<string, float> posts){

		yield return StartCoroutine (GrabScores (name));
		Facebook.postContent ();
		yield return new WaitForSeconds (1);

		if (!string.IsNullOrEmpty (serverResponse.error)) {
			//log error from server, grabscores.php
			print ("error downloading scores: " + serverResponse.error + " " + serverResponse.text);
			yield break;
		}

		string messageString;

		if (serverResponse.text.Length != 0) {
			//returning user
			Dictionary<string,string> server = serverData(serverResponse);
			postDick = compare.CompareDicks (server["posts"]);
			messageString = determineNewMessages.newMessages (Facebook.postMessages,server["messages"]); 
//			Debug.Log (messageString);
		} else {
			//new user
			postDick = fbInit.facebookDict;
			addLikes.addDickLikes (postDick);
			messageString = serializeInfo.SaveMessages (Facebook.postMessages);
		}

		string stringDick = serializeInfo.Save (postDick);


		yield return StartCoroutine (PostScores (name, stringDick, compare.likeTotal,messageString));

		if (!string.IsNullOrEmpty(serverResponse.error)) {
			print ("There was an error posting the high score: " + serverResponse.error);
		} else {
			Debug.Log ("It worked on this end");
		}


	}

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, string posts, float likes, string messages)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//Debug.Log("2." + name + " " + score);
		string hash = GameEngine.Md5Sum(name + posts + secretKey);

		string post_url = addScoreURL + "name=" + name + "&posts=" + posts + "&hash=" + hash + "&likes=" + likes + "&messages=" + messages;

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
//		Debug.Log("FROM ADDSCORE.PHP"+hs_post.text);
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

	public Dictionary<string,string> serverData(WWW server){
		string[] splitString = server.text.Split (new string[] {"</next>"},StringSplitOptions.None);
		Dictionary<string,string> dict = new Dictionary<string,string>();
		int x = 0;

		foreach(string split in splitString){

			if(!string.IsNullOrEmpty(split)){
			string[] dictString = split.Split (new string[] {"<and>"},StringSplitOptions.None);
			dict.Add (dictString[0],dictString[1]);
//				Debug.Log (dictString[0] + ": " + dictString[1]);
		}

		}
		return dict;
	}

	public static void uploadMessages(List<string> newIds)
	{
		
	}

}