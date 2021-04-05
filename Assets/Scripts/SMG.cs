using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    [Header("Gun FX")]
    public ParticleSystem GunShot;
    public AudioSource GunSound;

    [Header("Gun Settings")]
    public float damage = 10f;
    public float range = 100f;
    public Transform ShootPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Shoot();
        }
    }



    void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(ShootPos.transform.position, ShootPos.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            GunShot.Play();
            if (target != null){
                target.TakeDamage(10);
            }
        }
    }
}
