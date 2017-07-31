using Facebook.Unity;
using Facebook.MiniJSON;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class fbInit : MonoBehaviour {

	List<string> perm;
	private Dictionary<string,object> FBUserDetails;
	private Dictionary<string,object> PostDetails;
	private Dictionary<string,object> FBName;
	public string fbID;

	private int likeCount;
	private int postCount;
	private int postNumber;

	public game_engine GameEngine;

	public objectDictionary ObjectGeneration;
	public phpComm phpCommunication;
	public bool start;

	public Dictionary<string,float> likePerPost;
	public Dictionary<string,string> postMessages;

	public string likeID;
	public string postID;

	public string get_data;
	public string userName;

	public bool newPost;

	public static Dictionary<string, float> facebookDict;

	// Awake function from Unity's MonoBehavior
	void Awake ()
	{
		start = false;
		newPost = true;
		GameEngine = gameObject.GetComponent<game_engine>();
		ObjectGeneration = gameObject.GetComponent<objectDictionary> ();
		phpCommunication = gameObject.GetComponent<phpComm> ();

		facebookDict = new Dictionary<string,float> ();
		likePerPost = new Dictionary<string,float> ();
		postMessages = new Dictionary<string,string> ();

		perm = new List<string> () { "public_profile", "email", "user_friends", "user_posts" };

		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(internLogin);
		}

	}

	void internLogin(){
		FB.LogInWithReadPermissions(perm, AuthCallback);
	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			fbID = aToken.UserId;
			//Debug.Log(fbID);
			// Print current access token's granted permissions
//			foreach (string perm in Facebook.Unity.AccessToken.CurrentAccessToken.Permissions) {
//				Debug.Log(perm);
//			}

			retrieveName ();
		} else {
			Debug.Log("User cancelled login");
		}
	}

	void retrievePosts(){
		FB.API ("/me/posts?fields=likes.summary(true)&limit=30", HttpMethod.GET,postsCallback,new Dictionary<string,string>(){});
	}

	public void postContent(){
		FB.API ("/me/posts?limit=30", HttpMethod.GET,postText,new Dictionary<string,string>(){});
	}

	void retrieveName(){
		FB.API("/me?fields=first_name", HttpMethod.GET, nameCallback);
	}

	void nameCallback(IGraphResult result){
//		Debug.Log (result.RawResult);
		FBName = (Dictionary<string,object>)result.ResultDictionary;
		userName = FBName ["first_name"].ToString();
		GameEngine.userName = userName;
		retrievePosts ();
//		Debug.Log (userName);

	}


	private void postsCallback(IGraphResult result){
		
//		Debug.Log (result.RawResult);

		FBUserDetails = (Dictionary<string,object>)result.ResultDictionary;

		var postresultList = new List<object> ();
		postresultList = (List<object>)(FBUserDetails["data"]);

		//Debug.Log ("POST LIST: "+postresultList.Count);

		foreach(object keyValue in postresultList)
		{
			var post = keyValue as Dictionary<string,object>;
			postID = post ["id"].ToString();
//			Debug.Log (postID);
			Dictionary<string,object> likes = (Dictionary<string,object>)post ["likes"];
			Dictionary<string,object> summary = (Dictionary<string,object>)likes["summary"];
			string test = summary ["total_count"].ToString ();

			likeCount =  Convert.ToInt32(test);

			facebookDict.Add (postID, likeCount);

		}
//		phpCommunication.downloadInfo (userName);
		StartCoroutine(phpCommunication.ServerConnection(userName,facebookDict));
	}

	private void postText(IGraphResult result){
//		Debug.Log (result.RawResult);

		Dictionary<string,object> postStuff = (Dictionary<string,object>)result.ResultDictionary;
		var postMsgs = new List<object> ();
		postMsgs = (List<object>)postStuff ["data"];
		foreach (object keyVal in postMsgs) {
			var post = keyVal as Dictionary<string,object>;
			string message = post ["message"].ToString ();
			string id = post ["id"].ToString ();
			Debug.Log (message + " " + id);
			postMessages.Add (id, message);
		}

	}
		
}

