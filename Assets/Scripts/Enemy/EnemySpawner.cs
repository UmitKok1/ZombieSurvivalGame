using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool = null;
    [SerializeField] private float spawnSpan;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnSpan);
        }
 
    }
    float x, z;
    void SpawnEnemy()
    {
        GameObject temp = objectPool.GetPooledObject(1);
        x = Random.Range(0f, 20f);
        z = Random.Range(0f, 20f);
        temp.transform.position = new Vector3(x, 0, z);
        temp.transform.rotation = Quaternion.identity;
        Debug.Log("x = " + x);
        Debug.Log("z = " + z);
    }
}
