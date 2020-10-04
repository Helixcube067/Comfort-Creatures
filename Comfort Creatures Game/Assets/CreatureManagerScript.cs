using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManagerScript : MonoBehaviour
{

	public Transform[] creatures;
	public List<Transform> cookies;

	float checkTimer = 0.25f;
	float checkTimerDelta = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		checkTimerDelta += Time.deltaTime;
		if(checkTimerDelta > checkTimer) {
			checkTimerDelta = 0f;
			CookieCheck();
		}
    }

	public void CookieCheck() {
		for(int i = 0; i < creatures.Length; i++) {
			foreach (Transform cookie in cookies) {
				if(creatures[i].GetComponent<MyRigidbodySeek>().target == null) {
					creatures[i].GetComponent<MyRigidbodySeek>().target = cookie.gameObject;
				}
				float newCookieDist = (creatures[i].position - cookie.transform.position).magnitude;
				float prevCookieDist = (creatures[i].position - creatures[i].GetComponent<MyRigidbodySeek>().target.transform.position).magnitude;
				
				if(newCookieDist < prevCookieDist) {
					creatures[i].GetComponent<MyRigidbodySeek>().target = cookie.gameObject;
				}
			}

		}
	}

	//this is super important, if we don't drop cookies from everyone on deletion,
	//we will get SO MANY null ref errors
	public void RemoveCookie(Transform cookie) {
		cookies.Remove(cookie);
		for (int i = 0; i < creatures.Length; i++) {
			if (creatures[i].GetComponent<MyRigidbodySeek>().target != null) {
				if (creatures[i].GetComponent<MyRigidbodySeek>().target.Equals(cookie.gameObject))
					creatures[i].GetComponent<MyRigidbodySeek>().target = cookie.gameObject;
			}
		}
		CookieCheck();
	}
}
