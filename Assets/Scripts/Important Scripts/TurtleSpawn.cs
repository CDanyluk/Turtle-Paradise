using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleSpawn : MonoBehaviour
{

    //spawn random objects: http://forum.brackeys.com/thread/random-objects/
    public Terrain terrain;

    // Enemies spawn variables
    public int numOfEnemies; // number of objects to place
    private int currentEnemies; // number of placed objects 
    public GameObject enemyToPlace;

    // Food spawn variables
    public int numOfFood;
    private int currentFood;
    public GameObject foodToPlace;

    // Terrain for spawning size
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z

    // Points
    private int points;
    private GUIStyle guiStyle = new GUIStyle();

    // Hearts
    private int hearts;


    // Start is called before the first frame update
    void Start()
    {

        currentEnemies = 0;
        currentFood = 0;

        // Point system
        points = 0;

        // Health system
        hearts = 5;

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
        if (currentEnemies < numOfEnemies)
        {
            GenerateObject(enemyToPlace);
            currentEnemies += 1;
        } else if (currentFood < numOfFood)
        {
            GenerateObject(foodToPlace);
            currentFood += 1;
        }
    }

    // When the hearts are gone: die
    void FixedUpdate()
    {
        if (hearts < 0)
        {
            FindObjectOfType<GameManager>().EndGame();

        }
    }

    // Add the object given to a random point on the terrain
    private void GenerateObject(GameObject obj)
    {
        // generate random x position
        int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        // generate random z position
        int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
        // get the terrain height at the random position
        float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
        // create new gameObject on random position
        GameObject newObject = (GameObject)Instantiate(obj, new Vector3(posx, posy, posz), Quaternion.identity);
    }

    // Collision event
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "food")
        {
            points = points + 10;
            Destroy(collision.gameObject);
            currentFood -= 1;
            numOfEnemies += 1;
        }else if (collision.collider.tag == "enemy")
        {
            Destroy(collision.gameObject);
            hearts = hearts - 1;
            currentEnemies -= 1;
        }

    }

    //Handles the text in the corner
    void OnGUI()
    {
        guiStyle.fontSize = 40;
        int TextWidth = 200;
        GUI.Label(new Rect(Screen.width - TextWidth, 10, TextWidth, 100), "Points: " + points.ToString(), guiStyle);
        GUI.Label(new Rect(Screen.width - TextWidth, 35, TextWidth, 100), "Lives: " + hearts.ToString(), guiStyle);
    }

}
