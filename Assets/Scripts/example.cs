using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    [SerializeField] GameObject Worm, Tentacle, Bat, Eye, Mushroom, Image;
    int rng;
    GameObject[] ingredients = new GameObject[5];
    GameObject[] randomIngredients = new GameObject[3];
    List<int> list = new List<int>();

    void Start() {
        Image.SetActive(false);
        ingredients[0] = Worm;
        ingredients[1] = Tentacle;
        ingredients[2] = Bat;
        ingredients[3] = Eye;
        ingredients[4] = Mushroom;
    }

    void OnCollisionEnter(Collision box) {
        if (box.gameObject.CompareTag("Bar")) {
            for (int i = 0; i < 3; i++) {
                rng = Random.Range(0, 5);
                list.Add(rng);
            }
        }
        for (int i = 0; i < 3; i++) {
            randomIngredients[i] = ingredients[list[i]];
        }
    }

}
