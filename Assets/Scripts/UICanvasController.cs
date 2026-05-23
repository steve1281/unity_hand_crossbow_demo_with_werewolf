using TMPro;
using UnityEngine;

public class UICanvasController : MonoBehaviour
{
    [Header("Movement Items")]
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI ammoValue;

    private int ammoAmount;
    private int scoreAmount;

    public static UICanvasController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        scoreValue.text = "0";
        ammoValue.text = "0";
        
    }
    private void Update()
    {
        scoreValue.text = ammoAmount.ToString();
        ammoValue.text = ammoAmount.ToString();
    }
    public void SetScoreValue(int value)
    {
        scoreAmount = value;
    }

    public void SetAmmoValue(int value)
    {
        ammoAmount = value;
    }
}
