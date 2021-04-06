using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour
{
    public Camera NormalCam;
    public Camera ADSCam;
    public Transform playerGun;


    // Start is called before the first frame update
    void Start()
    {
        ADSCam.enabled = false;
        NormalCam.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        bool isAiming = ADSCam.enabled;

        if (Input.GetKeyDown(KeyCode.Mouse1) && !isAiming){
            Debug.Log("aiming Down sights");
            ADSCam.enabled = true;
            float mouseY = Input.GetAxis("Mouse Y") * 400 * Time.deltaTime;
            playerGun.Rotate(Vector3.up * mouseY);
        }
        
         if(Input.GetKeyDown(KeyCode.Mouse1) && isAiming){
            Debug.Log("Stopped Aiming");
            ADSCam.enabled = false;
            NormalCam.enabled = true;
        }





    }



}
