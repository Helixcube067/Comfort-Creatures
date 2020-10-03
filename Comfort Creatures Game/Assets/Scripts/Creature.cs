using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An individual creature in the game world. */
public class Creature : MonoBehaviour
{
	public int creatureType;	// 
	public void SetType (int type) {
		creatureType = type;
	}
	
	public int creatureSize;	// current size of creature
	public void SetSize (int size) {
		creatureSize = Mathf.Max(size,1);
	}
	
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
