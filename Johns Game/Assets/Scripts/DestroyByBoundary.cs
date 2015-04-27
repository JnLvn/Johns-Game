using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);   // Once object exits the boundary it is destroyed 
	}

}
