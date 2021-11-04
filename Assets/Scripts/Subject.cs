using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject
{

    void RegisterObserver(Observer observer);


   void RemoveObserver(Observer observer);

     void NotifyObserver();

}
