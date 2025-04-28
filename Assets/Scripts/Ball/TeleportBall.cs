using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;


public class TeleportBall : MonoBehaviour
{
    private Rigidbody rb;
    private ParticleSystem psBall;
    Vector3 tempVelocity;
    Transform targetPortal, sourcePortal;
    BallScore ballScore;
    private string lastPortal = "";

    void Start()
    {
        Destroy(gameObject, 10);
        rb = GetComponent<Rigidbody>();
        psBall = GetComponentInChildren<ParticleSystem>();
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
        string nextPortalTag = "";

        switch (tag)
        {
            case "Portal 1":

            if (GameObject.FindGameObjectWithTag("Portal 2") != null)
            {
                psBall.Pause();
                nextPortalTag = "Portal 2";
                

                targetPosition = GameObject.FindGameObjectWithTag("Spawn 2").transform.position;
                targetPortal = GameObject.FindGameObjectWithTag("Portal 2").transform;
                sourcePortal = GameObject.FindGameObjectWithTag(tag).transform;
                GetComponent<BallScore>().score += 10;
                Debug.Log("BallScore Added" + GetComponent<BallScore>().score);
                
                

                tempVelocity = rb.linearVelocity;      
                          
            }
            break;

            case "Portal 2":
                if (GameObject.FindGameObjectWithTag("Portal 3") != null)
                {
                    psBall.Pause();
                    nextPortalTag = "Portal 3";

                    targetPosition = GameObject.FindGameObjectWithTag("Spawn 3").transform.position;
                    targetPortal = GameObject.FindGameObjectWithTag("Portal 3").transform;
                    sourcePortal = GameObject.FindGameObjectWithTag(tag).transform;
                    GetComponent<BallScore>().score += 10;
                    Debug.Log("BallScore Added" + GetComponent<BallScore>().score);
                    

                    tempVelocity = rb.linearVelocity;
                }
                else
                {
                    psBall.Pause();
                    nextPortalTag = "Portal 1";

                    targetPosition = GameObject.FindGameObjectWithTag("Spawn 1").transform.position;
                    targetPortal = GameObject.FindGameObjectWithTag("Portal 1").transform;
                    sourcePortal = GameObject.FindGameObjectWithTag(tag).transform;
                    GetComponent<BallScore>().score += 10;
                    Debug.Log("BallScore Added" + GetComponent<BallScore>().score);
                    
                    
                    tempVelocity = rb.linearVelocity;
                }
                break;

            case "Portal 3":
                psBall.Pause();
                nextPortalTag = "Portal 1";

                targetPosition = GameObject.FindGameObjectWithTag("Spawn 1").transform.position;
                targetPortal = GameObject.FindGameObjectWithTag("Portal 1").transform;
                sourcePortal = GameObject.FindGameObjectWithTag(tag).transform;
                GetComponent<BallScore>().score += 10;
                Debug.Log("BallScore Added" + GetComponent<BallScore>().score);
                

                tempVelocity = rb.linearVelocity;               
                break;
        }

        if (nextPortalTag != "")
        {
            lastPortal = tag;
            StartCoroutine(Teleport(targetPosition, targetPortal, sourcePortal, tempVelocity));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == lastPortal)
        {
            psBall.Play();
            Debug.Log("Exited portal: " + other.tag);
            lastPortal = ""; // reset lock
            GetComponent<BallScore>().score += 10;
        }
    }

    IEnumerator Teleport(Vector3 targetPosition, Transform targetPortal, Transform sourcePortal, Vector3 tempVelocity)
    {
        rb.linearVelocity = Vector3.zero;

        // Do teleport
        transform.position = targetPosition + (targetPortal.forward * 1f);

        // Apply velocity in portal direction
        Vector3 localVelocity = sourcePortal.InverseTransformDirection(tempVelocity);
        localVelocity.y = - localVelocity.y;
        Vector3 newVelocity = targetPortal.TransformDirection(localVelocity);

        yield return null; // wait a frame just in case

        rb.linearVelocity = newVelocity;
    }
}