using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A parent object to instantiate, keep track of, and destroy Creature objects. */
public class CreatureManager : MonoBehaviour
{
	public Creature creaturePrefab;	// assign in editor
	List<Creature> creatures;
	
	public int sizeTotal;	// current sum of creatureSize of all creatures
	public int sizeLimit;	// level ends when sizeTotal reaches sizeLimit
	
	/* destroy all creature objects currently in list */
	public void DestroyCreatures () {
		if (creatures != null)
			foreach (Creature c in creatures)
				Destroy(c.gameObject);
	}
	
	/* create new creature objects and store them in list */
	public void InstantiateCreatures (List<int> types, List<int> sizes) {
		DestroyCreatures();
		
		if (creaturePrefab == null) return;	// sanity check: missing prefab
		int count = Mathf.Min(types.Count, sizes.Count);	// sanity check: list mismatch
		
		creatures = new List<Creature>();
		for (int i = 0; i < count; i++) {
			Creature c = Instantiate<Creature>(creaturePrefab);	// instantiate object
			c.transform.SetParent(transform, false);	// set CreatureManager as parent object
			c.SetType(types[i]);	// type
			c.SetSize(sizes[i]);	// initial size
			creatures.Add(c);	// add object to list
		}
	}
	
	/* add up creature sizes */
	public void CheckTotal () {
		int total = 0;
		foreach (Creature c in creatures) total += c.creatureSize;
		if (sizeTotal != total) {
			// update GUI?
			sizeTotal = total;
		}
	}
	
    void Start()
    {
		// test code: create a group of creatures, then replace it with another
        List<int> testTypes, testSizes;
		testTypes = new List<int>{0,0,0,0};
		testSizes = new List<int>{1,1,2,3};
		InstantiateCreatures(testTypes, testSizes);
		testTypes = new List<int>{0,0,1};
		testSizes = new List<int>{1,1,10};
		InstantiateCreatures(testTypes, testSizes);
    }

    void Update()
    {
        
    }
}
