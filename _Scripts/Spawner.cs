using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //left = 0, mid = 1, right = 2
    public GameObject[] lanes;

    public GameObject enemyPrefab;
    public float spawnDistance;

    public AudioProcessor processor;

    public float SpectrumSensitivity;
    private bool validFrame;

    private float nextAvailableSpawn;
    [SerializeField]
    private float beatInterval;
    public void StartSpawning()
    {
        validFrame = false;
        processor.onBeat.AddListener(SpawnEnemy);
        processor.onSpectrum.AddListener(EvaluateSpectrum);
    }

    public void StopSpawning()
    {
        processor.onBeat.RemoveListener(SpawnEnemy);
        processor.onSpectrum.RemoveListener(EvaluateSpectrum);
    }

    public void EvaluateSpectrum(float[] spectrum)
    {
        for (int i = 5; i < spectrum.Length; ++i)
        {
            if (spectrum[i] >= SpectrumSensitivity) 
            {
                validFrame = true;
            }
                
        }
    }

    public void SpawnEnemy()
    {
        if (!validFrame || nextAvailableSpawn >= Time.time)
            return;

        GameObject e = Instantiate(enemyPrefab, 
            lanes[Random.Range(0,3)].transform.position + new Vector3(0, 0, spawnDistance),
            Quaternion.identity);
        e.GetComponent<Enemy>().speed = 30f;
        nextAvailableSpawn = Time.time + beatInterval;
        validFrame = false;
    }
}
