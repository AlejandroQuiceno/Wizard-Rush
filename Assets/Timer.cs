using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text timerShow;
    [SerializeField] TimeEvents TimeEvents;
    public double timeSustract;
    public int time;
    // Update is called once per frame
    void Update()
    {
        time = 15 - (int)timeSustract;
        timerShow.text = ("Time: ") + time;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Client"))
        {
            timeSustract += Time.deltaTime;
            TimeEvents.timeSustract += Time.deltaTime;
        }
    }
}
