using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome_Start : Biome {

    public Transform prefabStartBiome;

    void Start()
    {
        parent = this.transform;
        Spawn();
    }

    public override void Spawn()
    {
        Vector3 pos = transform.position;
        GameObject go = Instantiate(prefabStartBiome, pos, Quaternion.identity, parent).gameObject;

        biomeObjects.Add(gameObject);
        biomeObjects.Add(go);
    }
}
