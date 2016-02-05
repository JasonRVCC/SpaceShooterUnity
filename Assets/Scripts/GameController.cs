using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int perfectBonus;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	//public GUIText perfectText;

	private bool gameOver;
	private bool restart;
	private int score;
	private int hitCount;
	//private Color perfectColor;
	//private Color fadeColor;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		//perfectText.text = "";
		score = 0;
		hitCount = 0;
		//perfectColor = perfectText.color;
		//fadeColor = perfectColor - new Color(0, 0, 0, 1.0f);
		UpdateScore ();
		StartCoroutine (SpawnWaves());
	}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(startWait);

		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
				                               spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			hitCount = 0;

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public int HitCount 
	{
		get {return hitCount;}
		set {hitCount = value;}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over. You Lose. Deal With It.";
		gameOver = true;
	}

	public void PerfectBonusScored ()
	{
		AddScore(perfectBonus);
		//perfectText.text = "+ " + perfectBonus;
		//perfectText.color = perfectColor;
		HitCount = 0;
		//while (perfectText.color.a >0) 
		//{
			//perfectText.color = Color.Lerp (perfectColor, fadeColor, 0.3f);
		//}
	}
}
