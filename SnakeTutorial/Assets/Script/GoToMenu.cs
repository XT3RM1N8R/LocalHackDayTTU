using UnityEngine;
using System.Collections;

public class GoToMenu : MonoBehaviour {

    public void Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
