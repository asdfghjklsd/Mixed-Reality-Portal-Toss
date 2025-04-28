using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab, ballSpawn, canvas, forceBar, particles;
    
    [SerializeField]private float minForce = 0.5f;
    [SerializeField]private float ballForce = 4f;
    [SerializeField] private float maxForceSeconds = 2.5f;
    private float ballForceCounter = 0f;
    private float shootForce = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            canvas.SetActive(true);
            ballForceCounter += Time.deltaTime;
            ballForceCounter = Mathf.Clamp(ballForceCounter, 0, maxForceSeconds);
            forceBar.transform.localScale = new Vector3(1, ballForceCounter/maxForceSeconds, 1);

            shootForce = ballForceCounter * ballForce;
        }
        if(!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            canvas.SetActive(false);
        }

        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && ballForceCounter > minForce)
        {
            particles.GetComponent<ParticleSystem>().Play();
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
