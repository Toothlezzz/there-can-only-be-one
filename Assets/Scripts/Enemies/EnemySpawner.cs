using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

[System.Serializable]

	public class Wave {
		public string waveName;
		public List<EnemyGroups> enemyGroups; //List of all the enemy objects
		public int waveQuota; //The total number of enemies to spawn in this wave
		public float spawnInterval; //The interval at which enemies spawn
		public int spawnCount; //The number of enemies already spawned in this wave
	}

[System.Serializable]

	public class EnemyGroups{
		public string enemyName;
		public int enemyCount; //The number of each enemies to spawn in this wave
		public int spawnCount; //The number of enemies already spawned in this wave
		public GameObject enemyPrefab;
	}

	public List<Wave> waves;
	public int currentWaveCount; //The index of current wave

	[Header("Spawner Attributes")]
	float spawnTimer; //Timer used to determine when to spawn a new enemy
	public float waveInterval; //The interval of time between waves

	Transform player;

    // Start is called before the first frame update
    void Start()
    {
	player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {

	if(currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0) {
		StartCoroutine(BeginNextWave());
	}
	
        spawnTimer += Time.deltaTime;

	if(spawnTimer >= waves[currentWaveCount].spawnInterval) {
		spawnTimer = 0f;
		SpawnEnemies();
	}
    }

	IEnumerator BeginNextWave() {
		yield return new WaitForSeconds(waveInterval);

		if(currentWaveCount < waves.Count - 1) {
			currentWaveCount++;
			CalculateWaveQuota();
		}
	}

	void CalculateWaveQuota() {
		int currentWaveQuota = 0;
		foreach (var enemyGroup in waves[currentWaveCount].enemyGroups){
			currentWaveQuota += enemyGroup.enemyCount;
		}
		waves[currentWaveCount].waveQuota = currentWaveQuota;
		Debug.LogWarning(currentWaveQuota);
	}

	void SpawnEnemies(){
		if(waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota) {
			foreach (var enemyGroup in waves[currentWaveCount].enemyGroups) {
				if (enemyGroup.spawnCount < enemyGroup.enemyCount) {
					Vector2 spawnPosition = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
					Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);

					enemyGroup.spawnCount++;
					waves[currentWaveCount].spawnCount++;
				}
			}
		}
	}
}
