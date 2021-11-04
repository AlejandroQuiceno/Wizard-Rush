using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverySubject : Subject
{

    private delivery del;

    private List<Observer> observers = new List<Observer>();

    public deliverySubject(delivery del)
    {
        this.del = del;
    }

    public void RegisterObserver(Observer observer)
    {
        this.observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        this.observers.Remove(observer);
    }

    public void NotifyObserver()
    {
       foreach (Observer obs in observers)
        {
            obs.Notify("La pocion ha sido creada");
        }
    }
}
