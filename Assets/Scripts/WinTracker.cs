using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTracker : MonoBehaviour
{
    [SerializeField] private GameObject Player_1;
    [SerializeField] private GameObject Player_2;

    [SerializeField] private GameObject Player_1_Wins_Text;
    [SerializeField] private GameObject Player_2_Wins_Text;

    [SerializeField] private bool Player_1_Won = false;
    [SerializeField] private bool Player_2_Won = false;



    [SerializeField] private GameObject RestartGameButton;
    [SerializeField] private GameObject MainMenuButton;

    void Update ()
    {

        if (Player_1 == null && Player_1_Won == false)
        {
            Player_2_Won = true;
            Destroy(Player_1_Wins_Text);
            Player_2_Wins_Text.SetActive(true);
            RestartGameButton.SetActive(true);
            MainMenuButton.SetActive(true);
        }

        if (Player_2 == null && Player_2_Won == false)
        {
            Player_1_Won = true;
            Destroy(Player_2_Wins_Text);
            Player_1_Wins_Text.SetActive(true);
            RestartGameButton.SetActive(true);
            MainMenuButton.SetActive(true);
        }

    }
}
