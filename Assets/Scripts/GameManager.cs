using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public NPCController npc;

    [SerializeField] private GameObject boltPrefab;
    [SerializeField] private Transform boltSpawnPoint;
    private GameObject bolt = null;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log($"pressed space");

            if (bolt != null)
            {
                Debug.Log($"Bolt already spawned; cannot instantiate a new one yet");
            }
            else
            {
                bolt = Instantiate(boltPrefab, boltSpawnPoint.position, boltSpawnPoint.rotation);
                bolt.tag = "Bolt";
            }
        }
    }
}
