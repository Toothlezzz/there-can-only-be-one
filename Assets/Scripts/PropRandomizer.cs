using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnProps()
    {
        foreach (GameObject prop in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            Instantiate(propPrefabs[rand], prop.transform.position, Quaternion.identity);
        }
    }
}
