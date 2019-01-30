using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject TitleScreenLogo;

    //all the button gameobjects
    [SerializeField] private GameObject StartGame_Button;

    [SerializeField] private GameObject Controls_Button;
    [SerializeField] private GameObject Close_Controles_Button;
    [SerializeField] private GameObject QuitGame_Button;

    //the image i want to show
    [SerializeField] private GameObject Controls_Image;

    public void Show_ControlsImage()
    {
        Controls_Image.SetActive(true);
        Close_Controles_Button.SetActive(true);

        TitleScreenLogo.SetActive(false);
        StartGame_Button.SetActive(false);
        Controls_Button.SetActive(false);
        QuitGame_Button.SetActive(false);
    }

    public void Close_ControlsImage()
    {
        TitleScreenLogo.SetActive(true);
        StartGame_Button.SetActive(true);
        Controls_Button.SetActive(true);
        QuitGame_Button.SetActive(true);

        Controls_Image.SetActive(false);
        Close_Controles_Button.SetActive(false);
    }
}