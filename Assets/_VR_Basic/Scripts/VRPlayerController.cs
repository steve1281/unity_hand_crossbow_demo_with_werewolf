using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayerController : MonoBehaviour
{
    [Header("Right Controller Actions")]
    [Tooltip("Link to the 'XRI RightHand/PrimaryButton' action")]
    public InputActionReference rightPrimaryButton; // A button

    [Tooltip("Link to the 'XRI RightHand/SecondaryButton' action")]
    public InputActionReference rightSecondaryButton; // B button

    [Header("Left Controller Actions")]
    [Tooltip("Link to the 'XRI LeftHand/PrimaryButton' action")]
    public InputActionReference leftPrimaryButton; // X button

    [Tooltip("Link to the 'XRI LeftHand/SecondaryButton' action")]
    public InputActionReference leftSecondaryButton; // Y button
    
    [Tooltip("Link to the 'XRI RightHand/Trigger' action")]
    public InputActionReference rightTrigger; // Trigger

    [Tooltip("Link to the 'XRI LeftHand/Trigger' action")]
    public InputActionReference leftTrigger; // Trigger

    [Tooltip("Link to the 'XRI RightHand/Grip' action")]
    public InputActionReference rightGrip; // Grip

    [Tooltip("Link to the 'XRI LeftHand/Grip' action")]
    public InputActionReference leftGrip; // Grip

    [Header("UI Panels")]
    public GameObject VR_UI;

    private void OnEnable()
    {
        // Subscribe to events for button press (when button is first pressed)
        rightPrimaryButton.action.performed += OnAButtonPressed;
        rightSecondaryButton.action.performed += OnBButtonPressed;
        leftPrimaryButton.action.performed += OnXButtonPressed;
        leftSecondaryButton.action.performed += OnYButtonPressed;
        rightTrigger.action.performed += OnRightTriggerPressed;
        leftTrigger.action.performed += OnLeftTriggerPressed;
        rightGrip.action.performed += OnRightGripPressed;
        leftGrip.action.performed += OnLeftGripPressed;


        // Don't forget to enable the actions
        rightPrimaryButton.action.Enable();
        rightSecondaryButton.action.Enable();
        leftPrimaryButton.action.Enable();
        leftSecondaryButton.action.Enable();
        rightTrigger.action.Enable();
        leftTrigger.action.Enable();
        rightGrip.action.Enable();
        leftGrip.action.Enable();

    }
    private void OnDisable()
    {
        // Unsubscribe from events and disable actions
        rightPrimaryButton.action.performed -= OnAButtonPressed;
        rightSecondaryButton.action.performed -= OnBButtonPressed;
        leftPrimaryButton.action.performed -= OnXButtonPressed;
        leftSecondaryButton.action.performed -= OnYButtonPressed;
        rightTrigger.action.performed -= OnRightTriggerPressed;


        rightPrimaryButton.action.Disable();
        rightSecondaryButton.action.Disable();
        leftPrimaryButton.action.Disable();
        leftSecondaryButton.action.Disable();
        rightTrigger.action.Disable();

    }
    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("A Button Pressed!");
    }

    private void OnBButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("B Button Pressed!");
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("X Button Pressed!");
    }

    private void OnYButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Y Button Pressed!");
        if (VR_UI == null) return;

        if (VR_UI.activeSelf == false)
        {
            VR_UI.SetActive(true);
        }
        else
        {
            VR_UI.SetActive(false);
        }
    }
    private void OnRightTriggerPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Right Trigger Pressed!");
    }
    private void OnLeftTriggerPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Left Trigger Pressed!");
    }
    private void OnLeftGripPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Left Grip Pressed!");
    }
    private void OnRightGripPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Right Grip Pressed!");
    }


}
