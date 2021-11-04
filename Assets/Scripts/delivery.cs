using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class delivery : MonoBehaviour
{
    [SerializeField] Text deliveryClient;
    [SerializeField] GameObject position, positionDelivery, potion;
    pickup pickup;
    NavMesh_Client_Controller nav;
    givesOrder gives;
    Boiler boiler;
    Counter counter;
    Potion poti;
    public int coun = 0; 
    public int coun2 = 0;//cuenta las pociones entregadas
    float timer = 0f;
    public bool cond1 = false;

    deliverySubject deliverysubject; //Esta monda es para el patron observer
    playerMovement pm;
    
    void Start() {
        deliveryClient.text = "Press E for delivery";
        pickup = FindObjectOfType<pickup>();
        counter = FindObjectOfType<Counter>();
        gives = FindObjectOfType<givesOrder>();
        boiler = FindObjectOfType<Boiler>();
        poti = FindObjectOfType<Potion>();

        deliverysubject = new deliverySubject(this); // esta monda tambien es para el observer
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        deliverysubject.RegisterObserver(pm.playerO);
    }
    void Update() {
        timer += Time.deltaTime;
        
        if (timer >= 0.4f) {
            timer = 0f;
            cond1 = false;
       }
    }
    void OnTriggerStay(Collider collider) {
        coun = 0;
        if (collider.gameObject.CompareTag("Player") && Counter.countText == 3) {
            poti.potion.gameObject.SetActive(false);// desactivacion de tomar pocion
            deliveryClient.gameObject.SetActive(true);
            
            if ((Input.GetKey(KeyCode.E))) {
                if (potion.transform.position == position.transform.position) {//proceso de verificacion de la pocion
                    for (int i = 0; i < 3; i++)
                    {
                        if (gives.randomIngredients[i].tag == boiler.ingredients2[i].tag)
                        {
                            coun++;
                        }
                    }
                    if(coun == 3) {
                        ConditionThird();
                        deliverysubject.NotifyObserver();
                    }
                    
                }
            } 
        }
    }
   
    void ConditionThird() {
        
        cond1 = true;
        potion.transform.SetParent(positionDelivery.transform);//sa hace hijo de la piscina de objetos
        potion.transform.position = positionDelivery.transform.position;
        pickup.Already = true;
        for(int i = 2; i >= 0; i--)
        {
            boiler.ingredients2.RemoveAt(i);
           
        }
       

        Debug.Log("coun:"+coun);
        coun = 0; coun2++;
        Counter.countText = 0;
        
    }

    void OnTriggerExit(Collider other) {
        deliveryClient.gameObject.SetActive(false);
    }
}
