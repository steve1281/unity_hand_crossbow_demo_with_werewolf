using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class MainManager : MonoBehaviour
{
    private void Start()
    {
        if (CheckVR())
        {
            SceneManager.LoadScene("Game");
        }
        
    }

    private bool CheckVR()
    {
        if (XRGeneralSettings.Instance == null
           || XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.Log("MainManager::CheckVR no VR detected.");
            return false;
        }

        Debug.Log("MainManager::CheckVR VR detected.");
        return true;
    }

    // called when Play button called.
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
