using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public Text potion;
    [SerializeField] GameObject worm, mushroom, bat, eye, tentacle, potion2; // potion2 = posicion piscina 
    [SerializeField] Transform posit1;// posicion pecho personaje
    Boiler boil;
    pickup pickup;
    AudioSource ready;
    Counter Counter;
    void Start() {
        potion.text = "Take Potion";
        boil = FindObjectOfType<Boiler>();
        pickup = FindObjectOfType<pickup>();
        Counter = FindObjectOfType<Counter>();
        ready = GetComponent<AudioSource>();
    }
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("Player") && boil.count2==3 && Counter.countText == 2) {
            Counter.countText = 3;
            boil.boiler.gameObject.SetActive(false); // desaparece presiona e
            potion.gameObject.SetActive(true);// se activa toma la pocion 
            if ((Input.GetKey(KeyCode.E)) && boil.count2 == 3) {
                potion2.transform.SetParent(posit1.transform);
                potion2.transform.localPosition = Vector3.zero;
                boil.count2 = 0; pickup.Already = true;
                ready.Play();
            }
        }
    }
}
/*                if (Input.GetKey(KeyCode.E)) {
                    potion2.transform.SetParent(position.transform);
                    potion2.transform.position = position.transform.position;
                    count2 = 0;*/