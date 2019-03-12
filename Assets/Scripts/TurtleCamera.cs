using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleCamera : MonoBehaviour
{

    // Control camera angle
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float mouseX;
    private float mouseY;
    public Camera cam;
    private float cameraDif;
    private Vector3 worldpos;

    // Text in corner
    private GUIStyle guiStyle = new GUIStyle();

    // Object reference
    public GameObject turt;

    // Start is called before the first frame update
    void Start()
    {
        cameraDif = cam.transform.position.y - turt.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Camera chagne angle
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        worldpos = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));

    }

    //Handles the text in the corner
    void OnGUI()
    {
        guiStyle.fontSize = 40;
        int TextWidth = 200;
        GUI.Label(new Rect(Screen.width - TextWidth, 10, TextWidth, 100), "Hello there", guiStyle);
    }
}
