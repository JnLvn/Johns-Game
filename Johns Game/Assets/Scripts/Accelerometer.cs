using UnityEngine;
using System.Collections;

public class Accelerometer : MonoBehaviour {

	public Boundary boundary;

	float speed = 10;
	float tilt = 5;
	Vector3 zeroAc;
	Vector3 curAc;
	float sensH = 10;
	float sensV = 10;
	float smooth = 0.5f;
	float GetAxisH = 0;
	float GetAxisV = 0;
	
	void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	}
	
	void Start(){
		ResetAxes();
	}
	
	void Update(){
		curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
		GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
		GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
		// now use GetAxisV and GetAxisH instead of Input. GetAxis vertical and horizontal
		// If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
		// in the above equations. If some axis is going in the wrong direction, invert the
		// signal (use -curAc.x or -curAc.y)

		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		//float translation = GetAxisV * speed;
		//float rotation = GetAxisH * rotationSpeed;

		float translation = GetAxisH * speed;
		float translation2 = GetAxisV * speed;
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		translation *= Time.deltaTime;
		translation2 *= Time.deltaTime;
		//rotation *= Time.deltaTime;
		
		// Move translation along the object's x-axis
		transform.Translate (translation, 0, 0);
		// Rotate around our y-axis
		//transform.Rotate (0, rotation, 0);

		//boundary
		transform.position = new Vector3 
			(
				Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (transform.position.z, boundary.zMin, boundary.zMax)
			);

		// tilt ship
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, transform.position.x * -tilt);

		
	}
}
