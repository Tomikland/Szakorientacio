﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome_Trees : Biome {

    public Transform treePrefab;
    public int treeCount = 10;

    // Use this for initialization
    void Start() {
        parent = this.transform;
        Spawn();
    }

    public Biome_Trees()
    {

    }

    // Update is called once per frame
    void Update () {
	    
	}

    public override void Spawn()
    {
        base.Spawn();

        for (int i = 0; i < treeCount; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-10,10), 0, Random.Range(-13, 13));
            GameObject go = Instantiate(treePrefab, pos, Quaternion.identity, parent).gameObject;

            biomeObjects.Add(go);
            
        }
    }
}
