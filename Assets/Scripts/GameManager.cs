using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UICanvasController ui = UICanvasController.instance;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
