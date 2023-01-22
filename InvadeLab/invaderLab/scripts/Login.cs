using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    public InputField nameF;
    public InputField pwdF;

    public Button submitButton;


    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", nameF.text);
        form.AddField("pwd", pwdF.text);
        WWW www = new WWW("http://localhost/sqlconnect/Login.php", form);
        yield return www;
        if (www.text == "S")
        {
            DBManagement.username = nameF.text;
            DBManagement.userid = www.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            
        }
        else if (www.text == "P")
        {
            DBManagement.username = nameF.text;
            DBManagement.userid = www.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
        else
        {
            Debug.Log("user Login failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameF.text.Length >= 4 && pwdF.text.Length >= 8);
    }


}
