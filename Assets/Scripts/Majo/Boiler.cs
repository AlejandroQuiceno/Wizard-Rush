using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boiler : MonoBehaviour
{
   
    public Text boiler;
    public GameObject[] objects= new GameObject[5];
    [SerializeField] GameObject position, position2; // positon= posicion jugador-- position2 = posicion piscina
    public List<GameObject> ingredients2 = new List<GameObject>(); // lista de los objetos en la pocion
    public int count2 = 0; // cuenta de los ingredientes 
    pickup pickup;
    
    IBoiler iboiler;

    void Start() {
        boiler.text = "Press E";
       
        pickup = FindObjectOfType<pickup>();
    }
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("Player") && Counter.countText == 1) {
            boiler.gameObject.SetActive(true);
            if ((Input.GetKey(KeyCode.E)) && count2 < 3) {            
                for (int i = 0; i < objects.Length; i++) {

                    if (objects[i].transform.position == position.transform.position) {
                        Debug.Log("Puesne");
                        iboiler = objects[i].GetComponent<IBoiler>();
                        ingredients2.Add(objects[i]);
                        Boil();
                    }
                }
                Counter.countText = 0; count();
            }
        }
    }
    void Boil() {   
       
        iboiler.Cook(position2.transform);
        count2++;
        pickup.Already = false;
    }
    void count() {
        if (count2 == 3) Counter.countText = 2;
    }

    void OnTriggerExit(Collider other) {
        boiler.gameObject.SetActive(false);
    }
} 
