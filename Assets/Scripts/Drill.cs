using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drill : MonoBehaviour
{

    public GameObject drill;
    public TextMesh drillTimer;
    public Text interaction;
    public GameObject door;
    public float drillTime = 30.0f;
    bool isDrilling;
    bool drillSpawned;
    private TextMesh drillText;
    private GameObject DrillClone;
    void Start()
    {
       interaction.enabled = false;
       isDrilling = false;
       drillSpawned = false;
    }

    void Update(){
        CheckDrillDoor();
    }


    void CheckDrillDoor(){

         Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
       if (Physics.Raycast(ray, out hit)){
           if (hit.transform.tag == "Sawable" || hit.collider.tag == "Sawable"){
                interaction.text = "Press [E] to place drill";
                interaction.enabled = true;
                if (Input.GetKeyDown(KeyCode.E) && !isDrilling && !drillSpawned){
                    isDrilling = true;
                if (isDrilling){
                     DrillClone = Instantiate(drill, new Vector3(16.719f, 0.5f, 4.4f), Quaternion.identity);
                     drillText = Instantiate(drillTimer, new Vector3(21.15519f, 2.664242f, 0.586f), Quaternion.Euler(0f, -180f, 0f));
                    drillSpawned = true;
                }
                
            }
           }
     
        } 


      
        
        if (isDrilling && drillSpawned){
            drillText.text = "Drill Timer: " + drillTime;
            interaction.enabled = false;
        
        drillTime -= Time.deltaTime;
        if (drillTime < 0)
        {   
            Destroy(DrillClone);
            Destroy(door);
            Destroy(drillText);
            isDrilling = false;
            drillSpawned = false;
        }
        }
    }

   

}