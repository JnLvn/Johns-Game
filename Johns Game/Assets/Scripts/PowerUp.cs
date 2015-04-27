using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public float ammoPowerUp;
	private PlayerController playerController;

	void Start ()
	{
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null)
		{
			playerController = playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")  // If the objects tag is boundary, do nothing
		{
			return;
		}

		if (other.tag == "Hazard")  // If the objects tag is Hazard, do nothing
		{
			return;
		}

		if (other.tag == "Player") // If objects tag is player, destroy and end game
		{
			playerController.ammo +=ammoPowerUp;
		}
		Destroy(gameObject);
	}

}
