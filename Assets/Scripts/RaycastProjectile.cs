using UnityEngine;

public class RaycastProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private LayerMask hitLayers;
    [SerializeField] private float maxLifetime = 60.0f;
    [SerializeField] private float hitLifetime = 10.0f;

    private Vector3 lastPosition;
    private Vector3 velocity;

    void Start()
    {
        lastPosition = transform.position;
        // Initial velocity in the direction the bolt is facing
        velocity = transform.forward * speed;
        Destroy(gameObject, maxLifetime);
    }

    void Update()
    {
        // 1. Calculate gravity/velocity over time
        velocity.y -= gravity * Time.deltaTime;

        // 2. Determine how far we would move this frame
        Vector3 step = velocity * Time.deltaTime;
        float stepMagnitude = step.magnitude;
        Vector3 stepDirection = velocity.normalized;

        // 3. Raycast from previous position to next intended position
        // This prevents "tunnelling" through thin walls at high speeds
        if (Physics.Raycast(lastPosition, stepDirection, out RaycastHit hit, stepMagnitude, hitLayers))
        {
            OnHit(hit);
        }
        else
        {
            // 4. If no hit, move the bolt and update lastPosition
            lastPosition = transform.position;
            transform.position += step;

            // Rotate bolt to face its current trajectory (weathervaning)
            if (velocity != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(velocity);
        }
    }

    void OnHit(RaycastHit hit)
    {
        Destroy(gameObject, hitLifetime);

        // Snap bolt to the hit point
        transform.position = hit.point;

        Debug.Log($"Hit {hit.collider.name}!");
        NPCController npc = hit.transform.GetComponent<NPCController>();
        if (npc != null)
        {
            npc.Hit();
        }

        // Example: Parent to the hit object so it sticks
        transform.SetParent(hit.transform);

        // Disable this script so it stops moving
        this.enabled = false;
    }
    private void OnDestroy()
    {

        Debug.Log($"Bolt {name} destroyed!");
    }

}
