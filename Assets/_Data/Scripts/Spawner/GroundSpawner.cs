using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : Spawner
{
    private static GroundSpawner instance;
    public static GroundSpawner Instance { get => instance; }

    [Header("Time")]
    [SerializeField] private float timeLimit = 1.5f;
    [SerializeField] private float timer = 0f;
    [Header("Terrain")]
    [SerializeField] private int numOfTerrain = 0;
    [SerializeField] private int maxOfCurTerrain;
    [SerializeField] private int maxOfTerrain = 5;
    [SerializeField] private Vector3 spawnPos;
    private float newX;

    protected override void Awake()
    {
        base.Awake();

        if (GroundSpawner.instance != null) Debug.LogError("Only 1 GroundSpawner allow");
        GroundSpawner.instance = this;
    }

    private void Start()
    {
        maxOfCurTerrain = Random.Range(1, maxOfTerrain + 1);

        UpdateNewSpawnPos();
    }

    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeLimit) return;

        if (CanSpawnTerrain()) SpawnTerrain();
        else SpawnSpike();

        UpdateNewSpawnPos();
        this.timer = 0f;
    }

    protected virtual bool CanSpawnTerrain()
    {
        return numOfTerrain < maxOfCurTerrain;
    }

    protected virtual void SpawnTerrain()
    {
        GroundSpawner.Instance.Spawn("Terrain", spawnPos, Quaternion.identity);
        numOfTerrain++;
    }

    protected virtual void SpawnSpike()
    {
        spawnPos.y = -9.33f;
        GroundSpawner.Instance.Spawn("Spike", spawnPos, Quaternion.identity);
        numOfTerrain = 0;
        maxOfCurTerrain = Random.Range(1, maxOfTerrain + 1);
    }

    protected virtual void UpdateNewSpawnPos()
    {
        newX = Random.Range(-2.5f, 2.5f);
        spawnPos = new Vector3(newX, -10f, 0f);
    }
}
