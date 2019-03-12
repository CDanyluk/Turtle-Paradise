//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    bool gameOver = false;
    string overString = "";
    private GUIStyle guiStyle = new GUIStyle();
    public Image endScreen;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.enabled = false;
    }

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            endScreen.enabled = true;

        }
        else if (gameOver == true)
        {
            if (Input.GetKeyDown("s"))
            {
                Restart();
            }

        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Handles the text in the corner
    void OnGUI()
    {
        guiStyle.fontSize = 70;
        int TextWidth = 200;
        GUI.Label(new Rect(Screen.width - TextWidth, 200, TextWidth, 20), overString, guiStyle);
    }

}
