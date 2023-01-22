using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Registration : MonoBehaviour
{
    public InputField nameF;
    public InputField dateF;
    public InputField pwdF;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", nameF.text);
        form.AddField("birthdate", dateF.text);
        form.AddField("pwd", pwdF.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("user created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("user creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameF.text.Length >= 4 && dateF.text.Length >= 9 && pwdF.text.Length >= 8);
    }
}
