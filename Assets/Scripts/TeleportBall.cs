using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;


public class TeleportBall : MonoBehaviour
{
    private Rigidbody rb;
    float tempVelocity;
    private string lastPortal = "";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag == lastPortal)
        {
            Debug.Log("Ignored re-entry into same portal: " + tag);
            return;
        }

        // Determine target portal
        Vector3 targetPosition = Vector3.zero;
        Quaternion targetRotation = Quaternion.identity;
        string nextPortalTag = "";

        switch (tag)
        {
            case "Portal 1":

            if (GameObject.FindGameObjectWithTag("Portal 2") != null)
            {
                nextPortalTag = "Portal 2";
                targetPosition = GameObject.FindGameObjectWithTag("Spawn 2").transform.position;
                targetRotation = GameObject.FindGameObjectWithTag("Portal 2").transform.rotation;
                tempVelocity = rb.linearVelocity.magnitude;
                
            }
            break;

            case "Portal 2":
                if (GameObject.FindGameObjectWithTag("Portal 3") != null)
                {
                    nextPortalTag = "Portal 3";
                    targetPosition = GameObject.FindGameObjectWithTag("Spawn 3").transform.position;
                    targetRotation = GameObject.FindGameObjectWithTag("Portal 3").transform.rotation;
                    tempVelocity = rb.linearVelocity.magnitude;
                }
                else
                {
                    nextPortalTag = "Portal 1";
                    targetPosition = GameObject.FindGameObjectWithTag("Spawn 1").transform.position;
                    targetRotation = GameObject.FindGameObjectWithTag("Portal 1").transform.rotation;
                    tempVelocity = rb.linearVelocity.magnitude;
                }
                break;

            case "Portal 3":
                nextPortalTag = "Portal 1";
                targetPosition = GameObject.FindGameObjectWithTag("Spawn 1").transform.position;
                targetRotation = GameObject.FindGameObjectWithTag("Portal 1").transform.rotation;
                tempVelocity = rb.linearVelocity.magnitude;
                break;
        }

        if (nextPortalTag != "")
        {
            lastPortal = tag;
            StartCoroutine(Teleport(targetPosition, targetRotation, tempVelocity));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == lastPortal)
        {
            Debug.Log("Exited portal: " + other.tag);
            lastPortal = ""; // reset lock
        }
    }

    IEnumerator Teleport(Vector3 targetPosition, Quaternion targetRotation, float tempVelocity)
    {
        rb.linearVelocity = Vector3.zero;

        // Do teleport
        transform.position = targetPosition + (targetRotation * Vector3.forward * 1f);

        // Apply velocity in portal direction
        Vector3 newVelocity = targetRotation * Vector3.forward * tempVelocity;
        yield return null; // wait a frame just in case
        rb.linearVelocity = newVelocity;
    }
}