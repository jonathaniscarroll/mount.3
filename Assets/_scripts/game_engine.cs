using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class game_engine : MonoBehaviour {
	
	public static int likes;
	public static string userName;
	public static Dictionary<string,float> serverDictionary;

//	public int posts;
	public int timer;


	public GameObject likeText;
	//public Text likeText;
	public TextMesh textupdate;
	public Text postText;

	public static TextMesh txtM;

	void Start () {
		timer = 0;
		txtM = likeText.GetComponent<TextMesh> ();
	}



	// Update is called once per frame
	void Update () {

//		if ( Input.GetKeyDown ( KeyCode.L )){
//			likes += 10;
//			setText(likes);
//		}

		if(likes < 0){
			likes = 0;
		}

	}

	public static void setText(int likecount){
		game_engine.txtM.text = "likes = " + likecount.ToString();
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