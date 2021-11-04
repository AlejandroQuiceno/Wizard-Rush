using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
   
    [SerializeField] GameObject position;
    public bool Already = false;
    [SerializeField]Boiler boiler;
    [SerializeField]Counter counter;

    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("PickUp") && Input.GetKey(KeyCode.E) && Already==false) {
            var pickUp = collider.GetComponent<IpickUp>();
            pickUp.Interact();
            Already = true;
        }
    }
}
