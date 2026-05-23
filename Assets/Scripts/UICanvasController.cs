using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class UICanvasController : MonoBehaviour
{
    [Header("Movement Items")]
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI ammoValue;

    public static UICanvasController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreValue.text = "0";
        ammoValue.text = "0";
        
    }

    public void SetScoreValue(int value)
    {
        scoreValue.text = value.ToString();
    }

    public void SetAmmoValue(int value)
    {

    }
}
