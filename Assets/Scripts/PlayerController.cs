using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Items")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private CharacterController charCon;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference lookAction;

    [Header("Camera Data")]
    [SerializeField] private Camera theCam;

    [Header("Locomotion Tuning")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float minLookAngle;
    [SerializeField] private float maxLookAngle;
    [SerializeField] private float lookSpeed;

    [Header("Weapon info")]
    [SerializeField] private GameObject boltPrefab;
    [SerializeField] private Transform boltSpawnPoint;
    [SerializeField] private InputActionReference attack;

    private GameObject bolt = null;


    [Header("Ammo info")]
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int ammoCnt = 0;

    [Header("Misc")]
    [SerializeField] private Animator animator;
    [SerializeField] private UICanvasController ui = UICanvasController.instance;

    private float ySpeed;
    private float horiRot;
    private float vertRot;

    // Update is called once per frame
    void Update()
    {
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

        // left/right 
        horiRot += lookInput.x * Time.deltaTime * lookSpeed;
        transform.rotation = Quaternion.Euler(0f, horiRot, 0f);

        // up/down
        vertRot -= lookInput.y * Time.deltaTime * lookSpeed;
        vertRot = Mathf.Clamp(vertRot, minLookAngle, maxLookAngle);
        theCam.transform.localRotation = Quaternion.Euler(vertRot, 0f, 0f);


        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Vector3 vertMove = transform.forward * moveInput.y;
        Vector3 horiMove = transform.right * moveInput.x;
        Vector3 moveAmount = horiMove + vertMove;
        moveAmount = moveAmount.normalized;
        moveAmount = moveAmount * moveSpeed;

        if (charCon.isGrounded)
        {
            ySpeed = 0f;

            if (jumpAction.action.WasPressedThisFrame())
            {
                ySpeed = jumpForce;
            }
        }

        // check before adding gravity
        if (moveAmount.magnitude > 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        ySpeed = ySpeed + (Physics.gravity.y * Time.deltaTime);

        moveAmount.y = ySpeed;
        charCon.Move(moveAmount * Time.deltaTime);

        if (attack.action.WasPressedThisFrame() && ammoCnt>0)
        {
            ammoCnt--;
            ui.SetAmmoValue(ammoCnt);
            animator.Play("BowShot"); 
            bolt = Instantiate(boltPrefab, theCam.transform.position, theCam.transform.rotation);
            bolt.tag = "Bolt";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            ammoCnt += 8;
            if (ammoCnt > maxAmmo) ammoCnt = maxAmmo;
            ui.SetAmmoValue(ammoCnt);
            Destroy(other.gameObject);
        }
    }
}
