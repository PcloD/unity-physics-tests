using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

/*
 * Gravity processing class that applies gravity to every object with a rigidbody within a radial range.
 */
public class GravityForce : MonoBehaviour {
	public float innerRadius = 1;
	public float outerRadius = 10;
	private Rigidbody rb = null;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		// Find all objects with a rigidbody that are within range.
		Rigidbody[] rbObjects = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];

		foreach(Rigidbody rb in rbObjects) {
			if((rb != this.rb)) {
				Vector3 posDiff = rb.gameObject.transform.position - gameObject.transform.position;
				float distance = posDiff.magnitude;
				if(distance < outerRadius) {
					// Work out percentage of full force to apply such that within the inner radius the 
					// full force is applied and ouside of this up to the outer radius the force is linearly reduced
					float percentage = 1 - (Mathf.Max(distance - innerRadius, 0) / (outerRadius - innerRadius));
					//Debug.Log("Range percentage: "+percentage);

					posDiff.Normalize();
					Vector3 force = -(posDiff * 9.8f * percentage);
					// Apply a force each frame
					rb.AddForce(force, ForceMode.Force) ;

					// Send a message to the object to update the up vector on any components that use it
					ExecuteEvents.Execute<IUpVectorChangeHandler>(rb.gameObject, null, (x,y)=>x.SetUpVector(posDiff));
				}
			}
		}
	}
}
