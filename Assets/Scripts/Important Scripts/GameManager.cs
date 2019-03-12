//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    bool gameOver = false;
    string overString = "";
    private GUIStyle guiStyle = new GUIStyle();

    public void EndGame ()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Debug.Log("GAME OVER");
            
        }else if (gameOver == true)
        {
            overString = "GAME OVER";
        }
    }

    void Restart()
    {

    }

    //Handles the text in the corner
    void OnGUI()
    {
        guiStyle.fontSize = 70;
        int TextWidth = 200;
        GUI.Label(new Rect(Screen.width - TextWidth, 200, TextWidth, 20), overString, guiStyle);
    }

}
