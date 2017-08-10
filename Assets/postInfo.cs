using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postInfo : MonoBehaviour {


	public class info
	{
		public float likes;
		public string posts;
		public info(int l, string p){
			likes = l;
			posts = p;
		}


	}

	public info thisInfo = new info(0,"");

	public void addText(string post,float likes){
		
		foreach(Transform child in transform){
			GameObject txtObj = child.gameObject;
			if (txtObj.name == "post") {
				txtObj.GetComponent<TextMesh> ().text = post;
				thisInfo.posts = post;
			} else {
				txtObj.GetComponent<TextMesh> ().text = likes.ToString();
				thisInfo.likes = likes;
			}

		}

	}
}
