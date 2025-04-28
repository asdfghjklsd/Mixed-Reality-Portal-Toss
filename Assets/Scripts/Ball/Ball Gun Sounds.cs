using UnityEngine;

public class BallGunSounds : MonoBehaviour
{
    public GameObject bar;
    private bool isPlaying = false;
    AudioSource aud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            aud.volume = 0.15f;
            aud.pitch = bar.transform.localScale.y + 1.5f;

            if(!isPlaying)
            {
                aud.Play();
                isPlaying = true;
            }
            
        }
        else
        {
            aud.volume = 0;
            isPlaying = false;
        }
        
    }
}
