using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour
{
    public float timeBetweenSpawns, spawnDistance;
    public Nucleon[] nucleonPrefabs;
    float timeSinceLastSpaawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        timeSinceLastSpaawn += Time.deltaTime;
        if (timeSinceLastSpaawn > timeBetweenSpawns)
        {
            timeSinceLastSpaawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }

    void SpawnNucleon()
    {
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
