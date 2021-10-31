using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClients : MonoBehaviour
{
    [SerializeField] GameObject[] clients = new GameObject[3];
    
    float timer = 0;
    [SerializeField] float spawnTime = 20;
    AudioSource bell;
    int indice = 0;
    void Start() {
        indice = Random.Range(0, 3);
        Instantiate(clients[indice], transform.position, Quaternion.identity);
        bell = GetComponent<AudioSource>();
        bell.Play();
        indice = Random.Range(0, 3);
    }

    void Update() {
        
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            Instantiate(clients[indice], transform.position, Quaternion.identity);
            timer = 0;
            bell.Play();
            indice = Random.Range(0, 3);
        }
    }
}
