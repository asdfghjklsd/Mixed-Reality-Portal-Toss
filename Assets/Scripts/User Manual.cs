using UnityEditor.UI;
using UnityEngine;

public class UserManual : MonoBehaviour
{
    public GameObject userManual;
    bool active = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        userManual.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
       if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
       {
            active = !active;
            userManual.SetActive(active);
       } 
    }
}
