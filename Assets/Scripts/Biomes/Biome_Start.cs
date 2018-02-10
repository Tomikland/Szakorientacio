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
        base.Spawn();
    }
}
