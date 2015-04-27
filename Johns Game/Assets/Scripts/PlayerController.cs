using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public GameObject shot1;
	public Transform shotSpawn;
	public Transform shotSpawn1;
	public float fireRate;
	public float ammo;
	private float nextFire;

	public GUIText ammoText;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); // get horizontal movement from input.
		float moveVertical = Input.GetAxis ("Vertical"); // get vertical movement from input.
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed; // move the rigidbody of the player, determined by input above.
		
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt); // make sure rigidbody does not leave the boundary.

		ammoText.text = "Ammo: " + ammo; // amount of ammo the player has.
	}

	void Update ()
	{
		// Takes input from fire button
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			if(ammo > 0)
			{
			nextFire = Time.time + fireRate; // calculates the time until next fire
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // create shot from player ship position1
			Instantiate(shot1, shotSpawn1.position, shotSpawn1.rotation); // create shot from player ship position2
			ammo--; // minus 1 from ammo
			audio.Play (); // play shot sound
			}
		}
	}
				


}
