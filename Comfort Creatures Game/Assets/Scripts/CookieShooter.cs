using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieShooter : MonoBehaviour
{

	public GameObject cookiePrefab;

	public float forceFactor;

	CreatureManagerScript manager;

	SceneMovement sceneMover;

	int cookieCount;
	// Start is called before the first frame update
	void Start()
    {
		cookieCount = 0;
		sceneMover = (SceneMovement)FindObjectOfType(typeof(SceneMovement));
		manager = (CreatureManagerScript)FindObjectOfType(typeof(CreatureManagerScript));
	}

    // Update is called once per frame
    void Update()
    {
		//if (cookieCount >= 15)
			//this here is for testing and will change argument to results screen of some sort
			//sceneMover.GameOver("Title Screen");
		if (Input.GetMouseButtonDown(0)) {
			GameObject cookieObj = Instantiate(cookiePrefab, transform.position + Vector3.back, transform.rotation);
			cookieObj.GetComponent<Rigidbody>().AddForce(-transform.position * forceFactor);
			manager.cookies.Add(cookieObj.transform);
			cookieCount++;
		}
    }
}
