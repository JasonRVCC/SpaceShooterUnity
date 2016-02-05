using UnityEngine;
using System.Collections;

public class ScoreGet : MonoBehaviour {

	//public int speed;
	private int score;
	private GUIText scoreGetText = GetComponent(GUIText);

	void Start()
	{
		scoreGetText.text = "Score";
		//rigidbody.velocity = transform.forward * speed;
	}

	int Score
	{
		get{return score;}
		set
		{
			score = value;
			//scoreText = "+ " + score;
		}

	}

	void Update()
	{

	}



}
