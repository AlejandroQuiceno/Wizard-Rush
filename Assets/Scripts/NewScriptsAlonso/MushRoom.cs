﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour, IpickUp
{
    // Start is called before the first frame update
    [SerializeField] GameObject player, gameObject;


    void pickMushroom()
    {
        
        gameObject.transform.SetParent(player.transform);
        gameObject.transform.position = player.transform.position;
        Counter.countText = 1;
    }
    public void Interact()
    {
        pickMushroom();
    }
   
}
