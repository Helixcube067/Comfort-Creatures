using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 mousePos = Input.mousePosition;
		
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		mousePos.z = 0;
		transform.position = mousePos;

	}
}
