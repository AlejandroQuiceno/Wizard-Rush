using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour, IpickUp
{
    [SerializeField] GameObject player, bat;
    Counter counter;
    private void Awake()
    {
        counter = FindObjectOfType<Counter>();
    }
    void pickBat()
    {
        
        bat.transform.SetParent(player.transform);
        bat.transform.position = player.transform.position;
        counter.countText = 1;
    }
    public void Interact()
    {
        pickBat();
    }
}
