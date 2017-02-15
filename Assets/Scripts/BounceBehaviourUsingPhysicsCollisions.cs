using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehaviourUsingPhysicsCollisions : MonoBehaviour {
    private Vector3 direction;
    public float speed = 2.0f;
    private Rigidbody rigidBody;
    private bool applyForce = true;


	// Use this for initialization
	void Start () {
        direction = new Vector3(Random.value, Random.value, Random.value);
        //Debug.Log("Initial Direction = " + direction);
        rigidBody = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        //Debug.Log("Physics update.  Delta time = "+Time.fixedDeltaTime);

        if(applyForce) {
            if(rigidBody != null) {
                Debug.Log("Direction = "+direction);
                Debug.Log("Speed = "+speed);
                Vector3 force = direction * speed;
                Debug.Log("Force = " + force);
                rigidBody.AddForce(force, ForceMode.Impulse);
                applyForce = false;
            }
            else {
                Debug.Log("No rigid body found");
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("OnCollision - current direction "+ direction);
        Vector3 normal = collision.contacts[0].normal;
        Debug.Log("Normal = " + normal);
        direction = Vector3.Reflect(direction, normal);
        //direction.Normalize();
        //Debug.Log("New Direction = " + direction);
        applyForce = true;
    }
}
