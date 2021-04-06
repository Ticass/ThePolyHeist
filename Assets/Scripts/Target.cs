using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 50f;
    public ParticleSystem epxlosion;
    public void TakeDamage (float amount){
        Health -= amount;

        if (Health <= 0){
            Die();
        }
    }


    void Die(){
        epxlosion.Play();
        Destroy(gameObject);
    }
}
