using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {

	public float speed;

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed; // move the shot fired by ship.
	}
}
