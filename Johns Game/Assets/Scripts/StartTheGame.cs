using UnityEngine;
using System.Collections;

public class StartTheGame : MonoBehaviour {

	public int highScore;
	string highScoreKey = "HighScore";

	public GUIText highScoreText;

	void Start()
	{
		// checks for highscore in player prefs. If no highscore set to zero.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		highScoreText.text = "High Score: " + highScore;
	}

	void OnGUI()
	{
		const int buttonWidth = 200;
		const int buttonHeight = 100;
		
		// Determine the button's place on screen.
		// Center in X, 2/3 of the height in Y.
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 6) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);

		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Play Game"))
		{
			// On Click, load the Main level.
			Application.LoadLevel("Main");
		}
	}
}
