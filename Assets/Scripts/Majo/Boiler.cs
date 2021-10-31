using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boiler : MonoBehaviour
{
    public Text boiler;
    public GameObject Worm, Mushroom, Bat, Eye, Tentacle;
    [SerializeField] GameObject position, position2; // positon= posicion cliente-- position2 = posicion piscina
    public List<GameObject> ingredients2 = new List<GameObject>(); // lista de los objetos en la pocion
    public int count2 = 0; // cuenta de los ingredientes 
    pickup pickup;
    Counter counter;

    void Start() {
        boiler.text = "Press E";
        counter = FindObjectOfType<Counter>();
        pickup = FindObjectOfType<pickup>();
    }
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("Player") && counter.countText == 1) {
            boiler.gameObject.SetActive(true);
            if ((Input.GetKey(KeyCode.E)) && count2 < 3) {
                if (Worm.transform.position == position.transform.position) {
                    First();
                } else if (Tentacle.transform.position == position.transform.position) {
                    Second();
                } else if (Bat.transform.position == position.transform.position) {
                    Third();
                } else if (Mushroom.transform.position == position.transform.position) {
                    Fourth();
                }  else if (Eye.transform.position == position.transform.position) {
                    Fifth();
                }
                counter.countText = 0; count();
            }
        }
    }
    void First() {
        ingredients2.Add(Worm);
        Worm.transform.SetParent(position2.transform); // hijo de la posicion2
        Worm.transform.position = position2.transform.position;
        count2++;
        pickup.count = 0;
    }
    void Second() {
        ingredients2.Add(Tentacle);
        Tentacle.transform.SetParent(position2.transform);
        Tentacle.transform.position = position2.transform.position;
        count2++;
        pickup.count = 0;
    }
    void Third() {
        ingredients2.Add(Bat);
        Bat.transform.SetParent(position2.transform);
        Bat.transform.position = position2.transform.position;
        count2++;
        pickup.count = 0;
    }
    void Fourth() {
        ingredients2.Add(Mushroom);
        Mushroom.transform.SetParent(position2.transform);
        Mushroom.transform.position = position2.transform.position;
        count2++;
        pickup.count = 0;
    }
    void Fifth() {
        ingredients2.Add(Eye);
        Eye.transform.SetParent(position2.transform);
        Eye.transform.position = position2.transform.position;
        count2++;
        pickup.count = 0;
    }

    void count() {
        if (count2 == 3) counter.countText = 2;
    }

    void OnTriggerExit(Collider other) {
        boiler.gameObject.SetActive(false);
    }
} 
