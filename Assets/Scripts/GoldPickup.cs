using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPickup : MonoBehaviour
{
    public Text goldHud;
    public Text goldInteract;
    public int PlayerAmountOfgold = 0;
    public int goldPerIngot = 1;
    public int maxCarry = 3;
    public Transform player;
    public GameObject Bag;
    public float PushForce = 60f;


    void SelectIngot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.tag == "Gold" || hit.transform.tag == "Gold"){
                goldInteract.text = "Press [E] to take gold";
                goldInteract.enabled = true;
                if (Input.GetKey(KeyCode.E) && hit.collider.tag == "Gold"){
                    if (PlayerAmountOfgold < 3){
                        PlayerAmountOfgold += goldPerIngot;
                         var goldIngot = hit.transform.gameObject;
                        Debug.Log(goldIngot);
                        Destroy(goldIngot);
                    }
                   
                }
            } else {
                goldInteract.enabled = false;
            }
        }
    }


    void CreateBag(){
        if (PlayerAmountOfgold == 3){
            if (Input.GetKey(KeyCode.B)){
                 Bag = Instantiate(Bag, player.transform.position, Quaternion.identity) as GameObject;
                Bag.GetComponent<Rigidbody>().AddForce(transform.forward * PushForce);
                PlayerAmountOfgold = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        goldInteract.enabled = false;
        PlayerAmountOfgold = 0;
    }

    void Awake(){
        string _Playergold = PlayerAmountOfgold.ToString();
        goldHud.text = _Playergold + "/3";
    }

    // Update is called once per frame
    void Update()
    {
         string _Playergold = PlayerAmountOfgold.ToString();
         goldHud.text = _Playergold + "/3";
         SelectIngot();
         CreateBag();
    }
}
