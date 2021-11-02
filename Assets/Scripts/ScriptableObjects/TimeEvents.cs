using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu]
public class TimeEvents : ScriptableObject
{
    
    public double timeSustract;
    [SerializeField] private double BaseTime = 0;
    public event UnityAction _TimeOut;
    private void OnEnable()
    {
        timeSustract = BaseTime;
    }
    public void timeOut()
    {
        
       _TimeOut?.Invoke();
        
    }
  
   
 
}
