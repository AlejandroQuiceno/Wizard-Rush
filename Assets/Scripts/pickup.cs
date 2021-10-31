using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    GameObject eye, mushroom, tentacle, bat, worm;
    [SerializeField] GameObject position;
    public int count = 0;
    Boiler boiler;
    Counter counter;

    private void Start() {
        boiler = FindObjectOfType<Boiler>();
        counter = FindObjectOfType<Counter>();
    }
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("Eye") && (Input.GetKey(KeyCode.E)) && (count ==0) && (boiler.count2 < 3)) {
            Eye();
        } else if (collider.gameObject.CompareTag("MushRoom") && (Input.GetKey(KeyCode.E)) && (count == 0) && (boiler.count2 < 3)) {
            Mushroom();
        } else if (collider.gameObject.CompareTag("Tentacle") && (Input.GetKey(KeyCode.E)) && (count == 0) && (boiler.count2 < 3)) {
            Tentacle();
        } else if (collider.gameObject.CompareTag("Bat") && (Input.GetKey(KeyCode.E)) && (count == 0) && (boiler.count2 < 3)) {
            Bat();
        } else if (collider.gameObject.CompareTag("Worm") && (Input.GetKey(KeyCode.E)) && (count == 0) && (boiler.count2 < 3)) {
            Worm();
        }
    }
    void Eye() {
        eye = GameObject.Find("Eye");
        eye.transform.SetParent(position.transform);
        eye.transform.position = position.transform.position;
        count++;
        counter.countText = 1;
    }
    void Mushroom() {
        mushroom = GameObject.Find("Hongo1 (1)");
        mushroom.transform.SetParent(position.transform);
        mushroom.transform.position = position.transform.position;
        count++;
        counter.countText = 1;
    }
    void Tentacle() {
        tentacle = GameObject.Find("tentacle (1)");
        tentacle.transform.SetParent(position.transform);
        tentacle.transform.position = position.transform.position;
        count++;
        counter.countText = 1;
    }
    void Bat() {
        bat = GameObject.Find("bat (1)");
        bat.transform.SetParent(position.transform);
        bat.transform.position = position.transform.position;
        count++;
        counter.countText = 1;
    }
    void Worm() {
        worm = GameObject.Find("gusano (1)");
        worm.transform.SetParent(position.transform);
        worm.transform.position = position.transform.position;
        count++;
        counter.countText = 1;
    }
}
