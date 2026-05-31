using TMPro;
using UnityEngine;

public class VRUICanvasController : MonoBehaviour
{
    [Header("Movement Items")]
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI ammoValue;

    private int ammoAmount;
    private int scoreAmount;

    public static VRUICanvasController instance;

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
        scoreValue.text = scoreAmount.ToString();
        ammoValue.text = ammoAmount.ToString();
    }
    public void SetScoreValue(int value)
    {
        scoreAmount += value;
    }
    public void SetAmmoValue(int value)
    {
        ammoAmount = value;
    }
}
