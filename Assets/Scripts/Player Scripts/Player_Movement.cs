using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //dit hieronder is voor de player Movement zoals in Asteroids
    [SerializeField] private Rigidbody2D Rigid2D;
    [SerializeField] private float ThrustSpeed = 100;
    [SerializeField] private bool Player_1 = false; //player playing on the left side of the keyboard
    [SerializeField] private bool Player_2 = false; //player playing on the right side of the keyboard

    private void FixedUpdate()
    {

        //player 1 controles

        if (Input.GetKey(KeyCode.A) && Player_1 == true)
        {
            Rigid2D.AddTorque(10f * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D) && Player_1 == true)
        {
            Rigid2D.AddTorque(-10f * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.W) && Player_1 == true)
        {
            Rigid2D.AddRelativeForce(Vector2.right * ThrustSpeed * Time.fixedDeltaTime);
        }

        //player 2 controles

        if (Input.GetKey(KeyCode.LeftArrow) && Player_2 == true)
        {
            Rigid2D.AddTorque(10f * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Player_2 == true)
        {
            Rigid2D.AddTorque(-10f * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && Player_2 == true)
        {
            Rigid2D.AddRelativeForce(Vector2.right * ThrustSpeed * Time.fixedDeltaTime);
        }

    }


}
