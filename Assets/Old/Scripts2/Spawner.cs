using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnRate = 5f, lastSpawn = 0f, spawnAmount = 0f;
    private System.Random rnd;
    public GameObject ship;
    private int rand;

    // Use this for initialization
    void Start () {
        InvokeRepeating("smallWave", 1f, 10f);
    }
	
	// Update is called once per frame
	void Update () {
        if ((Time.time > spawnRate + lastSpawn) && spawnAmount < 11f) {
            spawn();
            spawnAmount++;
            if (spawnAmount == 10) {
                spawnAmount = 0;
            }
            lastSpawn = Time.time + 0.5f;
        }
    }

    private void smallWave() {
        rand = (int)Random.Range(-30f, 30f);
    }

    private void spawn() { //enemy
        Vector2 pos = transform.position;
        Instantiate(ship, new Vector2(pos.x + rand, pos.y), transform.rotation); //improve random number generation
    }
}
