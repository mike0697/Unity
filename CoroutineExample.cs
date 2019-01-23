using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    [Range(0, 5)]
    public float waitTime = 0.5f;
    Coroutine CurrentCoroutine = null;

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator stopAfter()
    {
        yield return new WaitForSeconds(3.0f);
        StopCoroutine(CurrentCoroutine);

    }

    void Start()
    {
        CurrentCoroutine = StartCoroutine(SpawnCoroutine());
        StartCoroutine(stopAfter());
    }
}
