using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour, IpickUp 
{
    // Start is called before the first frame update
    [SerializeField] GameObject player, tentacle;
    Counter counter;
    private void Awake()
    {
        counter = FindObjectOfType<Counter>();
    }
    void pickTentacle()
    {
       
        tentacle.transform.SetParent(player.transform);
        tentacle.transform.position = player.transform.position;
        counter.countText = 1;
    }

    public void Interact()
    {
        pickTentacle();
    }
}
