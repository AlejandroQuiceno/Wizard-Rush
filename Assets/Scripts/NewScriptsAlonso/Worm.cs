using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour, IpickUp{
    [SerializeField] GameObject player, gameObject;


    void pickWorm()
    { 
        gameObject.transform.SetParent(player.transform);
        gameObject.transform.position = player.transform.position;
        Counter.countText = 1;
    }
    public void Interact()
    {
        pickWorm();
    }
  
}
