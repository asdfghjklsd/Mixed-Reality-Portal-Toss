using UnityEngine;


public class TeleportBall : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    private int teleportedFrom = -1;
    public AnchorPlacement anchorPlacement;
    private Vector3 tempVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0,0,1);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(anchorPlacement.totalPortals == 2)
        {
            if(other.CompareTag("Portal 1") && teleportedFrom == -1)
            {
                transform.position = portal2.transform.position;
                tempVelocity = portal2.transform.rotation * Vector3.forward * rb.linearVelocity.magnitude;           
                rb.linearVelocity = tempVelocity;
            }

            if(other.CompareTag("Portal 2") && teleportedFrom == -1)
            {
                tempVelocity = portal1.transform.rotation * Vector3.forward * rb.linearVelocity.magnitude;           
                rb.linearVelocity = tempVelocity;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(anchorPlacement.totalPortals == 2)
        {
            if(other.CompareTag("Portal 1"))
            {
                if (teleportedFrom == -1)
                {
                    teleportedFrom = 1;
                }
                if(teleportedFrom == 2)
                {
                    teleportedFrom = -1;
                }
            }

            if(other.CompareTag("Portal 2"))
            {
                if (teleportedFrom == -1)
                {
                    teleportedFrom = 2;
                }
                if(teleportedFrom == 1)
                {
                    teleportedFrom = -1;
                }
            }
        }
    }
}
