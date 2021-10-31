using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class boxPickups : MonoBehaviour
{
    [SerializeField] Text boxCollider;
    Boiler boiler; //referenciando script
    Counter counter; //referenciando script

    void Start() {
        boxCollider.text = "Press E";
        boiler = FindObjectOfType<Boiler>(); //obteniendo script a este
        counter = FindObjectOfType<Counter>();
    }
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player") && boiler.count2 < 3 && counter.countText == 0 ) { //para que aparezca texto
            boxCollider.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        boxCollider.gameObject.SetActive(false);
    }
}
