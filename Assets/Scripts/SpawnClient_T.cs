using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClient_T : MonoBehaviour
{
    [SerializeField] GameObject[] clients = new GameObject[3];

    float timer = 0;
    AudioSource bell;
    int indice = 0;
    void Start() {
        indice = Random.Range(0, 3);
        Instantiate(clients[indice], transform.position, Quaternion.identity);
        bell = GetComponent<AudioSource>();
        bell.Play();
        indice = Random.Range(0, 3);
    }
}
