using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_Prefab;
    [SerializeField] private GameObject Bullet_Spawn_Location_1;
    [SerializeField] private GameObject Bullet_Spawn_Location_2;

    [SerializeField] private bool Player_1 = false; //player playing on the left side of the keyboard
    [SerializeField] private bool Player_2 = false; //player playing on the right side of the keyboard

    [SerializeField] private bool Ammount_of_Bullets_1 = false;
    [SerializeField] private bool Ammount_of_Bullets_2 = false;

    [SerializeField] private ScreenShake shake;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Player_1 == true && Ammount_of_Bullets_1 == true)
        {
            GameObject blue_bullet_1 = Instantiate(Bullet_Prefab, Bullet_Spawn_Location_1.transform.position, transform.rotation);
            GiveShake(blue_bullet_1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Player_2 == true && Ammount_of_Bullets_1 == true)
        {
            GameObject blue_bullet_1 = Instantiate(Bullet_Prefab, Bullet_Spawn_Location_1.transform.position, transform.rotation);
            GiveShake(blue_bullet_1);
        }

        if (Input.GetKeyDown(KeyCode.S) && Player_1 == true && Ammount_of_Bullets_2 == true)
        {
            GameObject blue_bullet_1 = Instantiate(Bullet_Prefab, Bullet_Spawn_Location_1.transform.position, transform.rotation);
            GameObject blue_bullet_2 = Instantiate(Bullet_Prefab, Bullet_Spawn_Location_2.transform.position, transform.rotation);
            GiveShake(blue_bullet_1);
            GiveShake(blue_bullet_2);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Player_2 == true && Ammount_of_Bullets_2 == true)
        {
            GameObject blue_bullet_1 = Instantiate(Bullet_Prefab, Bullet_Spawn_Location_1.transform.position, transform.rotation);
            GameObject blue_bullet_2 = Instantiate(Bullet_Prefab, Bullet_Spawn_Location_2.transform.position, transform.rotation);
            GiveShake(blue_bullet_1);
            GiveShake(blue_bullet_2);
        }
    }

    private void GiveShake(GameObject obj)
    {
        obj.GetComponent<Bullet>().screenshake = shake;
    }
}