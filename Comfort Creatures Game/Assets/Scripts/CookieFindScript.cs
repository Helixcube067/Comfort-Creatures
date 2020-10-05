using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFindScript : MonoBehaviour
{

	//public Transform cookieTarget;

	CreatureManagerScript manager;

	public float size;

    // Start is called before the first frame update
    void Start()
    {
		manager = (CreatureManagerScript)FindObjectOfType(typeof(CreatureManagerScript));
		size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.transform.CompareTag("Cookie")) {
			manager.RemoveCookie(collision.transform);
			size++;
			transform.localScale *= 1.3f;
			GameObject.Destroy(collision.transform.gameObject);
		}
	}
}
