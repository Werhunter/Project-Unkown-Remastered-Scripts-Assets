using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Mines : MonoBehaviour
{
    [SerializeField] private GameObject Mine;

    [SerializeField] private bool Player_1 = false;  //player playing on the left side of the keyboard
    [SerializeField] private bool Player_2 = false; //player playing on the right side of the keyboard

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Player_1 == true)
        {
            Instantiate(Mine, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Player_2 == true)
        {
            Instantiate(Mine, transform.position, transform.rotation);
        }
    }
}
