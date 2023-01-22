using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceneload : MonoBehaviour
{
    public Text userPlayer;
    private void Start()
    {
        if (DBManagement.LoggedIn)
        {
            userPlayer.text = "User: " + DBManagement.username;
        }
    }

    public void GotoRegister()
    {
        SceneManager.LoadScene(2);
    }

}
