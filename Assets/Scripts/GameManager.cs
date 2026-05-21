using UnityEngine;

public class GameManager : MonoBehaviour
{
    public NPCController npc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        npc.Hit(3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
