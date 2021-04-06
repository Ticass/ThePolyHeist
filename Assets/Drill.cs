using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{

    public GameObject drill;
    public GameObject door;
    public float drillTime = 30.0f;
    void Start()
    {
        // drillTimer.text = "Press E to Drill";
    }


    void DrillDoor(){
        Debug.Log("Drilling Door");
        Instantiate(drill, new Vector3(16.719f, 0.5f, 4.4f), Quaternion.identity);
        drillTime -= Time.deltaTime;
        // drillTimer.text = "Drill Timer: " + drillTime;
        if (drillTime < 0)
        {   
            Destroy(drill);
            Destroy(door);
        }
    }

   

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Destroyable")){
            Debug.Log("Can Drill Door");
            if (Input.GetKeyDown(KeyCode.E)){
                DrillDoor();
            }
        } 
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyable")){
            Debug.Log("Can Drill Door");
             if (Input.GetKeyDown(KeyCode.E)){
                DrillDoor();
            }
        } 
    }
}
