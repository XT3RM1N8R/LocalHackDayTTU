using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	
    public void Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }


}
