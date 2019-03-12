using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    private Rigidbody rb;
    public float speed;

    // Hover variable
    public float hoverheight;

    // Points
    private int points;
    private GUIStyle guiStyle = new GUIStyle(); 

    // Start game variable
    private bool start;

    // Control camera angle
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float mouseX;
    private float mouseY;
    public Camera cam;
    private float cameraDif;
    private Vector3 worldpos;

    //spawn random objects: http://forum.brackeys.com/thread/random-objects/
    public Terrain terrain;
    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects 
    public GameObject objectToPlace; // GameObject to place
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z

    // Start is called before the first frame update
    void Start()
    {
        // Set variables
        rb = GetComponent<Rigidbody>();
        cameraDif = cam.transform.position.y - rb.transform.position.y;
        speed = 8f;
        start = false;
        points = 0;

        // Spawn random objects code, setting the boundaries of spawning
        // terrain size x
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)terrain.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // generate objects
        if (currentObjects <= numberOfObjects)
        {
            // generate random x position
            int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            // generate random z position
            int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            // get the terrain height at the random position
            float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
            // create new gameObject on random position
            GameObject newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, posy, posz), Quaternion.identity);
            currentObjects += 1;
        }

        // Float code
        Vector3 height = transform.position;
        height.y = Terrain.activeTerrain.SampleHeight(transform.position) + hoverheight;
        transform.position = height;
    }

    void GameOver()
    {
        start = false;
        transform.position = new Vector3(-0.2f, 0.82f, -51.79f);
    }

    void Win()
    {

    }

    void FixedUpdate()
    {

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    start = true;
        //}
        //if (start)
        //{
        if (Input.GetMouseButtonDown(0))
        {
            speed = 15;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            speed = 8;
        }

        //// Movement code
        //yaw += speed * Input.GetAxis("Mouse X");
        //pitch -= speed * Input.GetAxis("Mouse Y");
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        ////rb.transform.rotation = new Vector3(pitch, yaw, 0.0f);
        //transform.rotation = rb.transform.LookAt();


        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        worldpos = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));
        Vector3 turretLookDirection = new Vector3(worldpos.x, rb.transform.position.y, worldpos.z);
        rb.transform.LookAt(turretLookDirection);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
        //}
    }

    // Collision event
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "pickup")
        {
            Destroy(collision.gameObject);
            points = points + 10;
        }

    }

    //Handles the text in the corner
    void OnGUI()
    {
        guiStyle.fontSize = 40;
        int TextWidth = 200;
        GUI.Label(new Rect(Screen.width - TextWidth, 10, TextWidth, 100), "Points: " + points.ToString(), guiStyle);
    }
}