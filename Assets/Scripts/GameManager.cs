using System;
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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SpawnBadGuy();
        SpawnWereWolf();
        SpawnWolf();
    }
    private void SpawnBadGuy()
    {
       _ = Instantiate(badGuyPrefab, badGuySpawnPoint.position, badGuySpawnPoint.rotation);
    }
    private void SpawnWereWolf()
    {
       _ = Instantiate(wereWolfPrefab, wereWolfSpawnPoint.position, wereWolfSpawnPoint.rotation);
    }
    private void SpawnWolf()
    {
       _ = Instantiate(wolfPrefab, wolfSpawnPoint.position, wolfSpawnPoint.rotation);
    }
}
