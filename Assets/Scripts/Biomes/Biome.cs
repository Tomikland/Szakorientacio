using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour {

    public List<GameObject> biomeObjects;
    public Transform parent;
    public Transform basePrefab;
    

    public virtual void Spawn()
    {
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
        Vector3 pos = transform.position;
        GameObject go = Instantiate(basePrefab,pos,Quaternion.identity,parent).gameObject;

        biomeObjects.Add(gameObject);
        biomeObjects.Add(go);
    }
}
