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

    void SpawnProps()
    {
        foreach (GameObject prop in propSpawnPoints)
        {
            // Choose a random prefab
            int rand = Random.Range(0, propPrefabs.Count);
            // Instantiate the prefab at the spawn point's position
            GameObject pr = Instantiate(propPrefabs[rand], prop.transform.position, Quaternion.identity);
            // Set the parent of the instantiated object
            pr.transform.parent = prop.transform;

            // Access the SpriteRenderer component
            SpriteRenderer spriteRenderer = pr.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Set the sorting layer to "Props"
                spriteRenderer.sortingLayerName = "Props";
            }
        }
    }
}
