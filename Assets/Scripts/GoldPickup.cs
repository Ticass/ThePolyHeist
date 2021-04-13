using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPickup : MonoBehaviour
{
    public Text goldHud;
    public Text goldInteract;
    public int PlayerAmountOfgold = 0;
    GameObject lastPointedIngot;
    public int goldPerIngot = 1;
    public int maxCarry = 3;


    void SelectIngot()
    {
        Ray ray = Camera.main.ViewportPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.tag == "gold" || hit.transform.tag == "gold"){
                Debug.Log("Can Grab gold");
                goldInteract.text = "Press [E] to take gold";
                goldInteract.enabled = true;
                if (Input.GetKey(KeyCode.E) && hit.collider.tag == "gold"){
                    PlayerAmountOfgold += goldPerIngot;
                    GameObject goldIngot = hit.transform.GetComponent<GameObject>();
                    Destroy(goldIngot);
                    Destroy(hit.transform.gameObject);
                }
            } else {
                goldInteract.enabled = false;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        goldInteract.enabled = false;
    }

    void Awake(){
        string _Playergold = PlayerAmountOfgold.ToString();
       goldHud.text = "$" + _Playergold;
    }

    // Update is called once per frame
    void Update()
    {
         string _Playergold = PlayerAmountOfgold.ToString();
         goldHud.text = "$" +_Playergold;
         SelectIngot();
    }
}
