using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public static float speed = -5f;

	// move the harard-objects down the screen at speed -5f( minus numbers indicate vertical drop).
	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}

}
