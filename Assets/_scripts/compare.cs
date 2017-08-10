using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class compare : MonoBehaviour {

	public game_engine GameEngine;
	public objectDictionary objDick;
	public static compare compareScript;

	public static float likeTotal;

	public static List<string> newPostIDs;

	// Use this for initialization
	void Start () {

		GameEngine = gameObject.GetComponent<game_engine> ();
		objDick = gameObject.GetComponent<objectDictionary> ();
		compareScript = this;
		newPostIDs = new List<string> ();
	
	}

	//need to change what this does.
	//instead of compare and return a new dictionary with updated like counts for each post, 
	//compare and return a dictionary of posts with only the new likes.
	//find the difference between likes of posts coming from facebook and likes of posts coming from server
	//add that to dictionary of post, as string
	public static Dictionary<string, float> CompareDicks (Dictionary<string, float> serverDick)
	{
		Dictionary<string, float> facebookDick = fbInit.facebookDict;
		List<string> serverPosts = new List<string> (serverDick.Keys);

		Dictionary<string, float> postsWithNewLikes = new Dictionary<string, float> ();

//		compare.listDict(serverDick,"server");
//		compare.listDict (facebookDick,"facebook");

		List<string> keys = new List<string> (facebookDick.Keys);

		float oldLikes = 0;
		int count = 0;
		float newLikes = 0;

		//for every post comin off facebook
		foreach (string key in keys) {	
			//the variable fbval is the like value of this current facebook post
			int fbval = (int)facebookDick [key];
			//if the facebook post is also on the server
			if (serverPosts.Contains (key)) {
				//add the likes from server to the variable representing the old likes
				oldLikes += serverDick[key];
				//if the value of likes of this faacebook post and the server post are not the same
				if ((int)serverDick[key] != fbval){
					//Add this value of likes to a dictionary, as value with the post as key.
					newLikes = fbval - (int) serverDick[key];
					postsWithNewLikes.Add (key,newLikes);

					Debug.Log ("New Likes: " + newLikes);
				}
				serverDick[key] = fbval;
//					Debug.Log(serverDick[key] +  " now = " + fbval);

			} else if (!serverDick.ContainsKey (key)) {
				newLikes += fbval;
//				Debug.Log ("Server does not contain post, adding");
				postsWithNewLikes.Add (key, fbval);
//				Debug.Log (serverDick [key]);
				newPostIDs.Add(key);
			}
			count++;

		}

//		Debug.Log ("RAW LIEKS " + newLikes);
		//rawLikes.generateLikeTokens (newLikes);
		//compareScript.GameEngine.setText ((int)oldLikes);
		//likeTotal = newLikes + oldLikes;
		return postsWithNewLikes;

	}
	//currently displaying only the likes from the most recent facebook grab, why?

	public static Dictionary<string,string> compareMessages (Dictionary<string,string> fbDict){

		Dictionary<string, string> servDict = new Dictionary<string,string>();

		List<string> keys = new List<string> (fbDict.Keys);

		foreach (string key in keys) {
			if (!servDict.ContainsKey (key)) {
				servDict.Add (key, fbDict [key]);
			}
		}
		return servDict;
	}

	public static void listDict(Dictionary<string,float> dictionary,string name)
	{
		int i = 0;
		string dict = name + ": ";
		foreach (KeyValuePair<string,float> x in dictionary) {
			dict += " Post: " + x.Key + " Like: " +  x.Value; 
			i++;
		}
		if (i >= dictionary.Count) {
//			Debug.Log (dict);
//			Debug.Log ("there are " + dictionary.Count + "posts in " + name);
		}
	}

}
