using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject islandPrefab;
    public GameObject missilePrefab;
    public int respawnIsland = 3;
    public int respawnMissile = 1;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(IslandWave());
        StartCoroutine(MissileWave());
    }
    private void spawnIsland()
    {
        GameObject a = Instantiate(islandPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 1.1f, UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
    }
    private void spawnMissile()
    {
        GameObject a = Instantiate(missilePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 1.1f, UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator IslandWave()
    {
        yield return new WaitForSeconds(respawnIsland);
        spawnIsland();
    }
    IEnumerator MissileWave()
    {
        yield return new WaitForSeconds(respawnMissile);
        spawnMissile();
    }
}