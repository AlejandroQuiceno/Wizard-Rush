using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour, IpickUp
{
    // Start is called before the first frame update
    [SerializeField] GameObject player, mushroom;
    Counter counter;
    private void Awake()
    {
        counter = FindObjectOfType<Counter>();
    }

    void pickMushroom()
    {
        
        mushroom.transform.SetParent(player.transform);
        mushroom.transform.position = player.transform.position;
        counter.countText = 1;
    }
    public void Interact()
    {
        pickMushroom();
    }
}
