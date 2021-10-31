using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseCondi : MonoBehaviour
{
    NavMesh_Client_Controller nav;

    [SerializeField] int limitLose;
    [SerializeField] int limitWin;
    [SerializeField] int indice;
    [SerializeField] GameObject music;
    [SerializeField] GameObject musicTense;
    int cont = 0;//contador de clientes no atendidos
    int contWin = 0;//contador de clientes atendidos 
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Client") {
            nav = other.GetComponent<NavMesh_Client_Controller>();//coge el componente especificamente del clon que entro en colision 
            if (nav.lose == true) {//cuenta cuando el clon no es atendido 
                cont++;
            }
            else if (nav.lose == false) {//cuanta cuandi el clon es atendido
                contWin++;
                
            }
        }
    }
    void Update() {
        if (cont >= limitLose && indice == 0) {
            SceneManager.LoadScene(3);
        }
        if (cont >= limitLose && indice == 1)
        {
            SceneManager.LoadScene(7);
        }
        if (cont >= limitLose - 1) {
            music.SetActive(false);
            musicTense.SetActive(true);
        }
        if (contWin >= limitWin && indice == 0) {
            SceneManager.LoadScene(6);
        }
        if (contWin >= limitWin && indice == 1) {
            SceneManager.LoadScene("Win");
        }
        if(contWin >= limitWin && indice == 3) {
            SceneManager.LoadScene(0);
        }
    }
}
