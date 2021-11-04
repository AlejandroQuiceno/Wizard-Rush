using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trash : MonoBehaviour {
    [SerializeField] Text trashGame;
    [SerializeField] GameObject positionTrash, position, worm, mushroom, bat, eye, tentacle, potion;
    [SerializeField] pickup pickup;
    [SerializeField] Boiler boiler;
    [SerializeField] Counter Counter; 
    void Start() {
        trashGame.text = "Press E for trash";
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            trashGame.gameObject.SetActive(true);
            if ((Input.GetKey(KeyCode.E))) {
                if (worm.transform.position == position.transform.position) {//si posicion de objeto es igual a posicion del jugador
                    Worm();
                } else if (mushroom.transform.position == position.transform.position) {
                    Mushroom();
                } else if (bat.transform.position == position.transform.position) {
                    Bat();
                } else if (eye.transform.position == position.transform.position) {
                    Eye();
                } else if (tentacle.transform.position == position.transform.position) {
                    Tentacle();
                } else if (potion.transform.position == position.transform.position) {
                    Potion();
                }
                remover(); 
            }
        }
    }
    void Worm() {
        worm.transform.SetParent(positionTrash.transform); //se transporte a position.trash
        worm.transform.position = positionTrash.transform.position;
        pickup.Already = false; //reinicia los objetos para no tomar mas de 3
        Counter.countText = 0; //para que el texto se reinicie que salga press E
    }
    void Mushroom() {
        mushroom.transform.SetParent(positionTrash.transform);
        mushroom.transform.position = positionTrash.transform.position;
        pickup.Already = false;
        Counter.countText = 0;
    }
    void Bat() {
        bat.transform.SetParent(positionTrash.transform);
        bat.transform.position = positionTrash.transform.position;
        pickup.Already = false;
        Counter.countText = 0;
    }
    void Eye() {
        eye.transform.SetParent(positionTrash.transform);
        eye.transform.position = positionTrash.transform.position;
        pickup.Already = false;
        Counter.countText = 0;
    }
    void Tentacle() {
        tentacle.transform.SetParent(positionTrash.transform);
        tentacle.transform.position = positionTrash.transform.position;
        pickup.Already = false;
        Counter.countText = 0;
    }
    void Potion() {
        potion.transform.SetParent(positionTrash.transform);
        potion.transform.position = positionTrash.transform.position;
        pickup.Already = false;
        Counter.countText = 0;
    }
    void OnTriggerExit(Collider other) {
        trashGame.gameObject.SetActive(false);
    }
    void remover() {
        for (int i = 2; i >= 0; i--)
        {
            boiler.ingredients2.RemoveAt(i); //remover listas

        }
    }
}
