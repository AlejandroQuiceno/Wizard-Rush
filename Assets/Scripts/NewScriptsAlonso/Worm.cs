using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour, IpickUp
{// Start is called before the first frame update
    [SerializeField] GameObject player, worm;
    Counter counter;
    private void Awake()
    {
        counter = FindObjectOfType<Counter>();
    }

    void pickWorm()
    {
       
        worm.transform.SetParent(player.transform);
        worm.transform.position = player.transform.position;
        counter.countText = 1;
    }
    public void Interact()
    {
        pickWorm();
    }
}
