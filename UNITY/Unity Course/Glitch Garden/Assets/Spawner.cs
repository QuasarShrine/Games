using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] entitiesToSpawn;

    private int cpt;


    // Use this for initialization
    void Start() {
        if (entitiesToSpawn.Length == 0) {
            Debug.LogError("No entities to spawn for " + name);
        }
    }

    // Update is called once per frame
    void Update() {
        foreach (GameObject attacker in entitiesToSpawn) {
            if (IsTimeToSpawn(attacker)){
                Spawn(attacker);
            }
        }
    }

    public void Spawn(GameObject entity) {
        GameObject spawnedEntity = Instantiate(entity, gameObject.transform.position, Quaternion.identity);
        spawnedEntity.transform.parent = transform;
    }

    private bool IsTimeToSpawn(GameObject attacker) {
        return true;
    }
}
