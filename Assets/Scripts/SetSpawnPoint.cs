using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    public GameObject ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            ball.GetComponent<SphereCollider>().isTrigger = true;
            ball.transform.position = transform.position;
            
            
        }

        if(ball.transform.position != transform.position)
        {
            ball.GetComponent<SphereCollider>().isTrigger = false;
        }
       
    }
}
