using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Player_Spawn_Location : MonoBehaviour
{
    [SerializeField] private GameObject player_1;
    [SerializeField] private GameObject player_2;

    void Start ()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        Vector2 dimensions = new Vector2(Camera.main.orthographicSize * Camera.main.aspect * 2f, Camera.main.orthographicSize * 2f);

        //set the position of player 1 (random x and random y)
        player_1.transform.position = new Vector2(
            Random.Range(min.x + dimensions.x * 0.1f, max.x - dimensions.x * 0.1f),
            Random.Range(min.y + dimensions.y * 0.1f, max.y - dimensions.y * 0.1f));

        //set the position of player 1 (random x and random y)
        player_2.transform.position = new Vector2(
            Random.Range(min.x + dimensions.x * 0.1f, max.x - dimensions.x * 0.1f),
            Random.Range(min.y + dimensions.y * 0.1f, max.y - dimensions.y * 0.1f));
    }
	
}
