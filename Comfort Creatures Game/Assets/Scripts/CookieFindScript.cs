using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFindScript : MonoBehaviour
{

	//public Transform cookieTarget;

	CreatureManagerScript manager;

	public float startSize = 1; //set this to setup differences in characters at start
	public float size = 1;
	public float scalingFactor;

    // Start is called before the first frame update
    void Start()
    {
		manager = (CreatureManagerScript)FindObjectOfType(typeof(CreatureManagerScript));
		//startSize = 1;
		for (int i = 1; i < startSize; i++) {
			size++;
			transform.localScale *= scalingFactor;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.transform.CompareTag("Cookie")) {
			manager.RemoveCookie(collision.transform);
			size++;
			transform.localScale *= scalingFactor;
			GameObject.Destroy(collision.transform.gameObject);
		}
	}
}
