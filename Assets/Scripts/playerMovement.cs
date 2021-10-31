using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MonoBehaviour {
    float magnitude = 5; 
    AudioSource steps;
    Animator animation;
    

    void Start() {
        steps = GetComponent<AudioSource>(); //audio pasos
        animation = GetComponent<Animator>(); // animacion
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.Q)) { //si se presiona Q twerkea
            animation.SetTrigger("twerk");
        }
         else{
            movimiento();
            angle();
         }
    }

    void movimiento() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(x, 0, z).normalized * magnitude;
        Vector3 displacement = velocity * Time.deltaTime; ///para que se desplace en el tiempo
        transform.position += displacement; //cambia la posicion

        if (x != 0 || z != 0) {
            animation.SetBool("movement", true); //activar animacion movimeinto
            steps.volume = 1; //empiece a sonar
        } else {
            animation.SetBool("movement", false); //desactivar animacion movimeinto
            steps.volume = 0; //desactivar sonar
        }
    }

    void angle() {
        if (Input.GetKey(KeyCode.W)) {
            transform.eulerAngles = new Vector3(0, 0, 0); //gira en direccion de la tecla que presiones (angulo)
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
}
