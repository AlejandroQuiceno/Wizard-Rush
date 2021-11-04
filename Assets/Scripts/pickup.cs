using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
   
    [SerializeField] GameObject position;
    public bool Already = false;
    Boiler boiler;
    Counter counter;


    private void Start() {
        boiler = FindObjectOfType<Boiler>();
        counter = FindObjectOfType<Counter>();
    }
    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("PickUp") && Input.GetKey(KeyCode.E) && Already==false) {
            var pickUp = collider.GetComponent<IpickUp>();
            pickUp.Interact();
            Already = true;
        }
    }
}
