using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {


	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
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
		if (other.tag == "Boundary")  // If the objects tag is Boundary, do nothing
		{
			return;
		}

		if (other.tag == "PowerUp")  // If the objects tag is powerUp, do nothing
		{
			return;
		}

		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") // If objects tag is player, destroy and end game
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		Destroy(other.gameObject);
		Destroy(gameObject);
		gameController.AddScore (scoreValue); // if hazard-object destroyed add to score.
	}

}
