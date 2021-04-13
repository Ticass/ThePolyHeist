using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraDie : MonoBehaviour
{

    Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
        anim.SetBool("isShot", false);
    }

    public float Health = 10f;
    public void TakeDamage (float amount){
        Health -= amount;

        if (Health <= 0){
           Die();
        }
    }


    void Die(){
        anim.SetBool("isShot", true);
    }
}
