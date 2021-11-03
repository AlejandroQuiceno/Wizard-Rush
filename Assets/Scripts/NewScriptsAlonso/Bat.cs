using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour, IpickUp
{
    [SerializeField] GameObject player, gameObject;
    
    void pickBat()
    { 
        gameObject.transform.SetParent(player.transform);
        gameObject.transform.position = player.transform.position;
        Counter.countText = 1;
    }
    public void Interact()
    {
        pickBat();
    }

    
}
