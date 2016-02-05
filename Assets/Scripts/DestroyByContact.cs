using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject scoreGet;
	//public GUIText scoreText = scoreGet.guiText;
	public int scoreValue;
	//public int perfectBonus;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary") 
		{ 
			return; 
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		if (other.tag == "Bolt") 
		{
			gameController.AddScore (scoreValue);
			Instantiate(scoreGet, transform.position, Quaternion.identity);
			gameController.HitCount += 1;
			if (gameController.HitCount == gameController.hazardCount)
			{
				gameController.PerfectBonusScored();
			}
		}
		Destroy(other.gameObject);
		Destroy (gameObject); 
	}
}
