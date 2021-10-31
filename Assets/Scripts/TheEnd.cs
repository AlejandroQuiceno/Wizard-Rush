using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public void BackToMain() {
        SceneManager.LoadScene(0);
    }

    public void Retry() {
        SceneManager.LoadScene(1);
    }
    public void NextLevel() {
        SceneManager.LoadScene(4);
    }
    public void Retry_() {
        SceneManager.LoadScene(4);
    }
}
