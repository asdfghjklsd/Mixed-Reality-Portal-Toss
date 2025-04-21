using UnityEngine;


public class TeleportBall : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    private int teleportedFrom = -1;
    private Vector3 tempVelocity;

    void Start()
    {
        
    }
    void Update()
    {
        Debug.Log(teleportedFrom);
    }
    
    void OnTriggerEnter(Collider other)
    {
        
            if(other.CompareTag("Ball") && teleportedFrom == -1 && CompareTag("Portal 1") && portal2.activeSelf == true)
            {
                other.transform.position = portal2.transform.position;
                tempVelocity = portal2.transform.rotation * Vector3.forward * other.GetComponent<Rigidbody>().linearVelocity.magnitude;           
                other.GetComponent<Rigidbody>().linearVelocity = tempVelocity;
            }

            if(other.CompareTag("Ball") && teleportedFrom == -1 && CompareTag("Portal 2"))
            {
                if(portal3.activeSelf == true)
                {
                    other.transform.position = portal3.transform.position;
                    tempVelocity = portal3.transform.rotation * Vector3.forward * other.GetComponent<Rigidbody>().linearVelocity.magnitude;           
                    other.GetComponent<Rigidbody>().linearVelocity = tempVelocity;
                }

                if(portal3.activeSelf == false)
                {
                    other.transform.position = portal1.transform.position;
                    tempVelocity = portal1.transform.rotation * Vector3.forward * other.GetComponent<Rigidbody>().linearVelocity.magnitude;           
                    other.GetComponent<Rigidbody>().linearVelocity = tempVelocity;
                }
                
            }

            if(other.CompareTag("Ball") && teleportedFrom == -1 && CompareTag("Portal 3"))
            {
                    other.transform.position = portal1.transform.position;
                    tempVelocity = portal1.transform.rotation * Vector3.forward * other.GetComponent<Rigidbody>().linearVelocity.magnitude;           
                    other.GetComponent<Rigidbody>().linearVelocity = tempVelocity;                
            }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            if(CompareTag("Portal 1"))
            {
                if (teleportedFrom == -1)
                {
                    teleportedFrom = 1;
                }
                if(teleportedFrom == 2)
                {
                    teleportedFrom = -1;
                }
                if(teleportedFrom == 3)
                {
                    teleportedFrom = -1;
                }
            }

            if(CompareTag("Portal 2"))
            {
                if (teleportedFrom == -1)
                {
                    teleportedFrom = 2;
                }
                if(teleportedFrom == 1)
                {
                    teleportedFrom = -1;
                }
                if(teleportedFrom == 3)
                {
                    teleportedFrom = -1;
                }
            }

            if(CompareTag("Portal 3"))
            {
                if (teleportedFrom == -1)
                {
                    teleportedFrom = 3;
                }
                if(teleportedFrom == 1)
                {
                    teleportedFrom = -1;
                }
                if(teleportedFrom == 2)
                {
                    teleportedFrom = -1;
                }
            }
        }   
    }
}
