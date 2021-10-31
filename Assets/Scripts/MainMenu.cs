using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainM;       //se serializan los objetos que contienen los botones de los menus
    [SerializeField] GameObject creditsM;
    [SerializeField] GameObject mainB;
    [SerializeField] GameObject creditsB;

    void Update() {
        if (Input.GetKey(KeyCode.R)) RestartGame();   //se reinicia al presionar 'r'
    } 
    [SerializeField] void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //carga el nivel 1
    }
    [SerializeField] void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reinicia el nivel en el que se esté
    }
    public void Tutorial() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+5); //carga el tutorial
    }
    [SerializeField] void GoToCreditsMenu() { //desactiva main y activa credits
        mainM.SetActive(false);
        mainB.SetActive(false);
        creditsB.SetActive(true);
        creditsM.SetActive(true);
    }
    [SerializeField] void GoToMainMenu() { //desactiva credits y activa main
        creditsM.SetActive(false);
        creditsB.SetActive(false);
        mainB.SetActive(true);
        mainM.SetActive(true);
    }
    [SerializeField] void QuitGame() { //cierra el juego
        Application.Quit();
    }
}
