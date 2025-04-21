using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ballSpawn;
    [SerializeField]private float minForce = 0.5f;
    [SerializeField]private float ballForce = 1f;
    private float ballForceCounter = 0f;
    private float shootForce = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            ballForceCounter += Time.deltaTime;
            Mathf.Clamp(ballForceCounter, 0, 2.5f);

            shootForce = ballForceCounter * ballForce;
        }

        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && ballForceCounter > minForce)
        {
            var ball = Instantiate(ballPrefab, ballSpawn.transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(ballSpawn.transform.rotation * Vector3.forward * shootForce, ForceMode.Impulse);

            ballForceCounter = 0;
        }

        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && ballForceCounter < minForce)
        {
            ballForceCounter = 0;
        }
        
    }
}
