using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float startMenuTime;

    private void Start()
    {
        if (startMenuTime <= 0) {
        }
        else { 
            Invoke("LoadNextLevel", startMenuTime);
        }
    }

    public void LoadLevel(string name) {

        SceneManager.LoadScene(name);
    }
    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void QuitRequest() {
        Application.Quit();
    }
}
