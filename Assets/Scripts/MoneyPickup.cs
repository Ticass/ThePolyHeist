using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPickup : MonoBehaviour
{
    public Text moneyHud;
    public Text moneyInteract;
    public int PlayerAmountOfMoney = 0;
    GameObject lastPointedStack;
    public int MoneyPerStack = 100;


    void SelectStack()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.tag == "Money" || hit.transform.tag == "Money"){
                Debug.Log("Can Grab money");
                moneyInteract.text = "Press [E] to take money";
                moneyInteract.enabled = true;
                if (Input.GetKey(KeyCode.E) && hit.collider.tag == "Money"){
                    PlayerAmountOfMoney += MoneyPerStack;
                    GameObject moneyStack = hit.transform.GetComponent<GameObject>();
                    Destroy(moneyStack);
                    Destroy(hit.transform.gameObject);
                }
            } else {
                moneyInteract.enabled = false;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        moneyInteract.enabled = false;
    }

    void Awake(){
        string _PlayerMoney = PlayerAmountOfMoney.ToString();
       moneyHud.text = "$" + _PlayerMoney;
    }

    // Update is called once per frame
    void Update()
    {
         string _PlayerMoney = PlayerAmountOfMoney.ToString();
         moneyHud.text = "$" +_PlayerMoney;
         SelectStack();
    }
}
