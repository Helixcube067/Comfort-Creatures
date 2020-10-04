using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieShooter : MonoBehaviour
{

	public GameObject cookiePrefab;

	public float forceFactor;

	CreatureManagerScript manager;

	// Start is called before the first frame update
	void Start()
    {
		manager = (CreatureManagerScript)FindObjectOfType(typeof(CreatureManagerScript));
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0)) {
			GameObject cookieObj = Instantiate(cookiePrefab, transform.position + Vector3.back, transform.rotation);
			cookieObj.GetComponent<Rigidbody>().AddForce(-transform.position * forceFactor);
			manager.cookies.Add(cookieObj.transform);
		}
    }
}
