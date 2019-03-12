using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//used https://www.youtube.com/watch?v=3uyolYVsiWc to figure out script
public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void Update() {
        if (health > numOfHearts){
            health = numOfHearts; 
        }
        for (int i = 0; i < hearts.Length; i++){
            if (i < health){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }if (i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    // When the hearts are gone: die
    void FixedUpdate()
    {
        if (health < 0)
        {
            FindObjectOfType<GameManager>().EndGame();

        }
    }

    // Collision event
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            health -= 1;
        }

    }

}
