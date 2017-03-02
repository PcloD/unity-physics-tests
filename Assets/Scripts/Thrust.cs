using UnityEngine;
using System.Collections;

/*
 * Example thrust for an object applied to the objects 'up' vector at a regular interval.
 * Used for testing.
 */
public class Thrust : MonoBehaviour, IUpVectorChangeHandler {
	private float time = 0; 
	public float jumpTime = 5;
	private Vector3 upVector = new Vector3(0,1,0);
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate() {
		if(rb == null) {
			Debug.Log("Invalid rigid body");
			return;
		}

		time += Time.fixedDeltaTime;

		if(time > jumpTime) {
			// Timer has expired so apply the thrust
			Vector3 force = upVector * 10.0f;
			rb.AddForce(force, ForceMode.Impulse);
			// Reset timer
			time = 0;
		}
	}


	// IUpVectorMessage implementation

	public void SetUpVector(Vector3 data) {
		Debug.Log("Set up vector called: "+data);
		this.upVector = data;
	}
}
