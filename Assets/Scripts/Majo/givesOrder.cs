using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class givesOrder : MonoBehaviour
{

    [SerializeField] GameObject Worm, Tentacle, Bat, Eye, Mushroom, Image;//imagenes de los ingredientes
    [SerializeField] Transform Pos1, Pos2, Pos3;//posiciones en el canvas
    int rng;
    public double clientTimer;
    GameObject[] ingredients = new GameObject[5];
    public GameObject[] randomIngredients = new GameObject[3];
    Transform[] positions = new Transform[3];//posiciones en el canvas
    int[] arrayNumbers = new int[3];//arreglo de numeros aleatorios
    GameObject clone1, clone2, clone3;//clones de las imagenes individuales
    [SerializeField] Text timer;//timer del cliente
    int temp = 0;
    void Update() {
        temp = 15-(int)clientTimer;
        timer.text = "Time:" + temp;
    }
    void Start() {
        
        Image.SetActive(false);
        ingredients[0] = Worm;//proceso innecesario 1
        ingredients[1] = Tentacle;
        ingredients[2] = Bat;
        ingredients[3] = Eye;
        ingredients[4] = Mushroom;
        positions[0] = Pos1;//proceso innecesario 2
        positions[1] = Pos2;
        positions[2] = Pos3;
    }
    void OnTriggerEnter(Collider box) {
        if (box.gameObject.CompareTag("Client")) {
            for (int i = 0; i < 3; i++) {//se crean tres numeros aleatorios y se guardan en el arreglo de numeros aleatorios 
                rng = Random.Range(0, 5);
                arrayNumbers[i] = rng;  
            }           
            for (int i = 0; i < 3; i++) randomIngredients[i] = ingredients[arrayNumbers[i]];//se ponen ingredientes aleatorios en el arreglo de randomingridients 
            for (int i = 0; i < 3; i++) {//esta moviendo las imagenes a las 3 posiciones que estan en el canvas, y se estan activando las imagenes 
                randomIngredients[i].transform.position = positions[i].position;
                Image.SetActive(true);
                randomIngredients[i].SetActive(true);
            }
            if (randomIngredients[0] == randomIngredients[1] && randomIngredients[1] == randomIngredients[2]&& randomIngredients[0] == randomIngredients[2]) {//pasa cuando los tres ingredientes son iguales
                ConditionFirst();
            } else {//pasa cuando dos ingredienets son iguales 
                ConditionSecond();
            }  
        }
    }
    void ConditionFirst() {// pasa cuando las tres imagenes son iguales,se crean dos clones de las imagenes ya que los imagenes tienen solo una de cada una, luego se mueven a las dos primeras posiciones 
        clone1 = Instantiate(randomIngredients[1], positions[0]) as GameObject;
        clone1.transform.SetParent(Image.transform);
        clone1.transform.localScale = randomIngredients[0].transform.localScale;
        clone2 = Instantiate(randomIngredients[1], positions[1]) as GameObject;
        clone2.transform.SetParent(Image.transform);
        clone2.transform.localScale = randomIngredients[0].transform.localScale;
    }

    void ConditionSecond() {
        if (randomIngredients[0] == randomIngredients[1]) {//pasa cuando la imagen numero uno es igual a la imagen numero dos, se crea una clon en la posicion 0;
            clone1 = Instantiate(randomIngredients[1], positions[0]) as GameObject;
            clone1.transform.SetParent(Image.transform);
            clone1.transform.localScale = randomIngredients[0].transform.localScale;
        }
        if (randomIngredients[1] == randomIngredients[2]) {//pasa cuando la imagen numero dos es igual a la imagen numero tres, se crea una clon en la posicion 1;
            clone2 = Instantiate(randomIngredients[2], positions[1]) as GameObject;
            clone2.transform.SetParent(Image.transform);
            clone2.transform.localScale = randomIngredients[1].transform.localScale;
        }
        if (randomIngredients[0] == randomIngredients[2]) {//pasa cuando la imagen numero uno es igual a la imagen numero tres , se crea una clon en la posicion 0;
            clone3 = Instantiate(randomIngredients[2], positions[0]) as GameObject;
            clone3.transform.SetParent(Image.transform);
            clone3.transform.localScale = randomIngredients[0].transform.localScale;
        }
    }

    public void OnTriggerStay(Collider other) {//se empieza a contar el tiempo que el cliente esta esperando 
        if (other.gameObject.CompareTag("Client")) {
            clientTimer += Time.deltaTime;
            
        }
    }
    void OnTriggerExit(Collider client) {
        if (client.gameObject.CompareTag("Client")) {//se desactivan las tres imagenes
            for(int i =0; i < 3; i++)
            {
                randomIngredients[i].SetActive(false);
            }
            
           //se eliminan los clones 
            if (randomIngredients[0] == randomIngredients[1]) Destroy(clone1);
            if (randomIngredients[1] == randomIngredients[2]) Destroy(clone2);
            if (randomIngredients[0] == randomIngredients[2]) Destroy(clone3);
            clientTimer = 0;//se resetea el timer cuando sale el cliente
        }
    }
}