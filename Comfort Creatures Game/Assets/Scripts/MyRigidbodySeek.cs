using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidbodySeek : MonoBehaviour
{
	//next frame vars
	Vector3 nextAngular;
	Vector3 nextLinear;

	public GameObject target; // This is the target, which we make decisions based on.

	//This is the Object being affected!
	public float maxSpeed;
	public float maxAccel;

	Rigidbody rb;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		nextAngular = Vector3.zero;
		nextLinear = Vector3.zero;
	}

	private void FixedUpdate() {
		SeekMove();
		CalculateNextMove();
	}

	void CalculateNextMove() {
		rb.velocity = rb.velocity + nextLinear * Time.fixedDeltaTime;
		rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + nextAngular);
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized;
			rb.velocity = rb.velocity * maxSpeed;
		}
		if (nextAngular == Vector3.zero) {
			rb.rotation = Quaternion.identity;
		}
		if (nextLinear.sqrMagnitude == 0.0f) {
			rb.velocity = Vector3.zero;
		}
		nextAngular = Vector3.zero;
		nextLinear = Vector3.zero;
	}

	void SeekMove() {
		if (target != null) {
			nextLinear = target.transform.position - transform.position;
			nextLinear.Normalize();
			nextLinear = nextLinear * maxAccel;
		}
	}
}
