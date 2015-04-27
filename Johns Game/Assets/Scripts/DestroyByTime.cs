using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifetime;

	// This is used to destroy the explosions created from destroying hazards.
	void Start ()
	{
		Destroy (gameObject, lifetime); // destroys object after certain time
	}
}
