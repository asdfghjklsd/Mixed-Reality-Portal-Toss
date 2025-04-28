using UnityEngine;

public class BallSounds : MonoBehaviour
{
    AudioSource aud;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aud = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        aud.pitch = 1f;
        aud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        aud.volume = rb.linearVelocity.magnitude/10;
        aud.volume = Mathf.Clamp(aud.volume, 0, 1f);
    }
}
