using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("BadGuy info")]
    [SerializeField] private GameObject badGuyPrefab;
    [SerializeField] private Transform badGuySpawnPoint;

    [Header("WereWolf info")]
    [SerializeField] private GameObject wereWolfPrefab;
    [SerializeField] private Transform wereWolfSpawnPoint;

    [Header("Wolf info")]
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private Transform wolfSpawnPoint;

    [Header("Blood Cloud info")]
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private float effectDuration = 1.5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SpawnBadGuy();
        StartCoroutine(SummonWereWolf());
        StartCoroutine(SummonWolf());
    }
    private void SpawnBadGuy()
    {
        _ = Instantiate(badGuyPrefab, badGuySpawnPoint.position, badGuySpawnPoint.rotation);
    }
    IEnumerator SummonWereWolf()
    {
        GameObject temp = Instantiate(badGuyPrefab, wereWolfSpawnPoint.position, wereWolfSpawnPoint.rotation); 
        GameObject spawnedCloud = Instantiate(cloudPrefab, wereWolfSpawnPoint.position, wereWolfSpawnPoint.rotation); 
        yield return new WaitForSeconds(effectDuration - 0.2f);
        _ = Instantiate(wereWolfPrefab, wereWolfSpawnPoint.position, wereWolfSpawnPoint.rotation);
        Destroy(temp);
    }
    IEnumerator SummonWolf()
    {
        GameObject temp = Instantiate(badGuyPrefab, wolfSpawnPoint.position, wolfSpawnPoint.rotation); 
        GameObject spawnedCloud = Instantiate(cloudPrefab, wolfSpawnPoint.position, wolfSpawnPoint.rotation); 
        yield return new WaitForSeconds(effectDuration - 0.2f);
        _ = Instantiate(wolfPrefab, wolfSpawnPoint.position, wolfSpawnPoint.rotation);
        Destroy(temp);
    }
}
