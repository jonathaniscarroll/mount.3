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

	void Start()
	{
		GameEngine = gameObject.GetComponent<game_engine> ();
		Facebook = gameObject.GetComponent<fbInit> ();
		newDick = new Dictionary<string,float> ();

		//Debug.Log("1."+userName + " " + likes);
		//StartCoroutine(GetScores());
	}

	public void collectNameAndLikes(string posts)
	{
		userName = GameEngine.userName;

		//Debug.Log("3."+userName + " " + likes);
		StartCoroutine (PostScores (userName, posts));
	}

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, string posts)
	{
		
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		//Debug.Log("2." + name + " " + score);
		string hash = GameEngine.Md5Sum(name + posts + secretKey);

		string post_url = addScoreURL + "name=" + name + "&posts=" + posts + "&hash=" + hash;
		//Debug.Log (post_url);

		//Debug.Log (post_url);

		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done

		if (hs_post.error != null) {
			print ("There was an error posting the high score: " + hs_post.error);
		} else {
			Debug.Log ("It worked on this end");
		}

		Facebook.postContent ();

//		Debug.Log (hs_post.text);

	}

	public void downloadInfo (string userName)
	{
		StartCoroutine (GrabScores(userName));
	}

	IEnumerator GrabScores(string name)
	{
		string hash = GameEngine.Md5Sum(name + secretKey);
		string post_url = grabScoreURL + "name=" + name + "&hash=" + hash;

		WWW grab = new WWW(post_url);
		yield return grab;



		if (grab.error != null) {
			print ("error downloading scores: " + grab.error);
		} else {
			Debug.Log ("loaded successful");

			if (grab.text.Length != 0) {
				
				//returning user
				//			Debug.Log ("DOWNLOADED: " + grab.text);
				string[] splitString = grab.text.Split (new string[] {"</next>"},StringSplitOptions.None);
				int state = int.Parse(splitString[0]);
//				Debug.Log (state);
				download = splitString[1];

				//			Debug.Log (download);
				newDick = compare.CompareDicks (download);
				compare.listDict (newDick, "dict to send to server: ");
//				addLikes.addDickLikes (newDick);
				string stringDick = serializeInfo.Save (newDick);
				collectNameAndLikes (stringDick);
				//figure out at which point in the game user is
				gameState.getState(state);

			} else {
				//new user
				addLikes.addDickLikes (fbInit.facebookDict);
				string stringDick = serializeInfo.Save (fbInit.facebookDict);
				collectNameAndLikes (stringDick);
			}

		}


	}

	public static void uploadMessages(List<string> newIds)
	{
		
	}


//	public void registerLikes(string likeID, string name)
//	{
//		//Debug.Log ("First Post " + likeID);
//		StartCoroutine(PostLikes(likeID,name));
//	}
//
//	IEnumerator PostLikes(string likeID, string name)
//	{
//		string hash = GameEngine.Md5Sum(name + secretKey);
//		string checkLikeID = registerlikesURL + "name=" + WWW.EscapeURL (name) + "&likeID=" + likeID + "&hash=" + hash;
//		WWW likeID_post = new WWW (checkLikeID);
//		yield return likeID_post;
//
//		if (likeID_post.error != null) {
//			print ("There was an error retrieving the like quantity: " + likeID_post.error);
//		} else {
//			Debug.Log ("like quantity worked on this end");
//		}
//
//		string result = likeID_post.text;
//		if (result == "stop") {
//			Debug.Log ("Stopper");
//			//Facebook.newLike = false;
//		}
//		//Debug.Log ("RESULT " + result);
//	}

}