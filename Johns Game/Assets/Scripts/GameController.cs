using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject powerUp;
	public Vector3 spawnValues;
	public int hazardCount;
	public int powUpCount;
	public float spawnWait;
	public float spawnWaitPowUp;
	public float startWait;
	public float startWaitPowUp;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private static int score;
	private int highScore;
	private bool gameOver;
	private bool restart;
	private string highScoreKey = "HighScore";

	//public Mover mover;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		StartCoroutine (SpawnPowerUp ());
		//Get the highScore from player prefs if it's there, zero otherwise. 
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}
			yield return new WaitForSeconds (waveWait);

			Mover.speed -=2f;  // increase hazard-objects speed by 2 after each wave

			if(gameOver)
			{
				break; // if game over, stop waves of hazard-objects.
			}

			score++; // increase score by 1 after each wave.
			UpdateScore();
		}
	}

	IEnumerator SpawnPowerUp ()
	{
		yield return new WaitForSeconds (startWaitPowUp);
		while (true)
		{
			for (int i = 0; i < powUpCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (powerUp, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWaitPowUp);
				
			}
			yield return new WaitForSeconds (waveWait);

			if(gameOver)
			{
				break; // if game over, stop waves of hazard-objects.
			}
		}
	}

	// adds scores from destroying hazard-objects.
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	void OnGUI()
	{
		const int buttonWidth = 200;
		const int buttonHeight = 100;
		
		// Determine the button's place on screen
		Rect buttonRect = new Rect(-5, 9, buttonWidth, buttonHeight);

		Rect buttonRect2 = new Rect (200, 8, buttonWidth, buttonHeight);
		
		// Draw a button to bring you to menu
		if(GUI.Button(buttonRect,"Menu"))
		{
			// On Click, load the Menu.
			Application.LoadLevel("Menu");
		}
		// Draw a button to restart the game
		if(GUI.Button(buttonRect2,"Restart"))
		{
			Mover.speed = -5f; // reset the speed of the hazard-objects everytime restart button pressed.
			// On Click, reload the Main level.
			Application.LoadLevel("Main");
		}

	}

	void OnDisable()
	{
		//If our scoree is greter than highscore, set new higscore and save.
		if(score>highScore){
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}
	}



}
