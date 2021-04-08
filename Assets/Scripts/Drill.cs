using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{

    public GameObject drill;
    public TextMesh drillTimer;
    public GameObject door;
    public float drillTime = 30.0f;
    bool isDrilling;
    bool drillSpawned;
    private TextMesh drillText;
    private GameObject DrillClone;
    void Start()
    {
        drillTimer.text = "Press E to Drill the door";
        drillText = Instantiate(drillTimer, new Vector3(21.15519f, 2.664242f, 0.586f), Quaternion.Euler(0f, -180f, 0f));
    }

    void Update(){
        CheckDrillDoor();
    }


    void CheckDrillDoor(){
        if (!drillSpawned && isDrilling){
            DrillClone = Instantiate(drill, new Vector3(16.719f, 0.5f, 4.4f), Quaternion.identity);
            drillSpawned = true;
        }
        
        if (isDrilling){
            drillText.text = "Drill Timer: " + drillTime;
             Debug.Log("Drilling Door");
        
        drillTime -= Time.deltaTime;
        if (drillTime < 0)
        {   
            Destroy(DrillClone);
            Destroy(door);
            isDrilling = false;
        }
        }
    }

   

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Destroyable") && !isDrilling){
            Debug.Log("Can Drill Door");
            if (Input.GetKeyDown(KeyCode.E) && !isDrilling){
                isDrilling = true;
            }
        } 
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyable") && !isDrilling){
            Debug.Log("Can Drill Door");
             if (Input.GetKeyDown(KeyCode.E) && !isDrilling){
                 isDrilling = true;
            }
        } 
    }
}
