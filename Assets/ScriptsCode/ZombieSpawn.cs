using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [Header("ZombieSpawn var")]
    public GameObject zombiePrefb;
    public Transform zombieSpawnPosition;
   // public GameObject dangerZone;
    private float repeatCycle = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 1f, repeatCycle);
            Destroy(gameObject, 10f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    void EnemySpawner()
    {
        Instantiate(zombiePrefb, zombieSpawnPosition.position, zombieSpawnPosition.rotation);
    }
}
