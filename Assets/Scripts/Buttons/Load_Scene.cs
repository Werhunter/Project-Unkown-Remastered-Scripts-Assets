using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    [SerializeField]
    private string scene;

    public void GameStart_OnButtonClick()
    {
        SceneManager.LoadScene(scene);
    }

}
