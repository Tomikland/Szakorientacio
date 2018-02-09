using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour {

    public List<GameObject> biomeObjects;
    public Transform parent;
    public Transform basePrefab;

    public virtual void Spawn()
    {
        Debug.Log("base.spawn");
        SpawnBase();
    }

    private void Start()
    {
        parent = this.transform;
        //Spawn();
    }

    public virtual void DeSpawn() //TODO: pooling
    {
        foreach (GameObject item in biomeObjects)
        {
            GameObject.Destroy(item);
        }
    }

    public virtual void SpawnBase()
    {
        
    }
}
