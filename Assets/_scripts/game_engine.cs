using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class game_engine : MonoBehaviour {
	public int likes;
	public int posts;
	public int timer;
	public string userName;

	public GameObject likeText;
	//public Text likeText;
	public TextMesh textupdate;
	public Text postText;

	public objectDictionary ObjectGeneration;

	void Start () {
		ObjectGeneration = gameObject.GetComponent<objectDictionary> ();

		timer = 0;
		likes = 0;
		posts = 0;
		setText(likes);
//		ObjectGeneration.populateCubicles (likes);
	}



	// Update is called once per frame
	void Update () {

		if ( Input.GetKeyDown ( KeyCode.L )){
			likes += 10;
			setText(likes);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
//			ObjectGeneration.populateCubicles (likes);
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			rawLikes.generateLikeTokens (likes);
		}

		timer += 1;
		if (timer > 500){
			timer = 0;
			setText(likes);
		}
		if(likes < 0){
			likes = 0;
		}
		if(posts < 0){
			posts = 0;
		}
	}

	public void setText(int likecount){
//		Debug.Log (likecount);
		likeText.GetComponent<TextMesh>().text = "likes = " + likecount.ToString();
		likes = likecount;
//		postText.text = "posts = " + posts.ToString();
	}

	public  string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		return hashString.PadLeft(32, '0');
	}
}