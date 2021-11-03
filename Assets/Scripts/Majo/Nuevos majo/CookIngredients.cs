using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookIngredients : MonoBehaviour, IBoiler {
    
     public  void Cook(Transform position2) {
        gameObject.transform.SetParent(position2.transform); // hijo de la posicion2
        gameObject.transform.position = position2.transform.position;

    }
   
}
