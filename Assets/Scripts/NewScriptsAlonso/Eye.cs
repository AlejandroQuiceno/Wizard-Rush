using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour, IpickUp
{
    // Start is called before the first frame update
    [SerializeField] GameObject player,eye;
    Counter counter;
    private void Awake()
    {
        counter = FindObjectOfType<Counter>();
    }

    void pickEye()
    {
        
        eye.transform.SetParent(player.transform);
        eye.transform.position = player.transform.position;
        counter.countText = 1;
    }
    public void Interact()
    {
        pickEye();
    }
}
