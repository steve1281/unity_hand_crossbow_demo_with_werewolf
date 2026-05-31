using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Management;

public class GameManager : MonoBehaviour
{

    [Header("Player options")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject vr_player;

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

    private void Awake()
    {
        if (CheckVR())
        {
            // VR is present, and our default, no changes
            vr_player.SetActive(true);
            player.SetActive(false);
            vr_player.transform.Find("Camera Offset").Find("Main Camera").GetComponent<AudioListener>().enabled = true;
            Debug.Log("GameManager::Awake VR detected.");
        } else
        {
            // VR is not present; need to make changes
            vr_player.SetActive(false);
            player.SetActive(true);
            player.transform.Find("Camera Offset").Find("Main Camera").GetComponent<AudioListener>().enabled = true;
            Debug.Log("GameManager::Awake VR Not detected.");
        }
    }
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

    private bool CheckVR()
    {
        if (XRGeneralSettings.Instance == null
           || XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            return false;
        }
        return true;
    }
}
