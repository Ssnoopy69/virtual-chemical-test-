using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Admintost : MonoBehaviour
{
    public InputField nameF;

    public Button submitButton;

    public Text res;


    public void CallStud()
    {
        StartCoroutine(Admintos());
    }

    IEnumerator Admintos()
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", nameF.text);
        WWW www = new WWW("http://localhost/sqlconnect/admincheck.php", form);
        yield return www;
        if (www.text != "0")
        {
            res.text = www.text;
        }
        else
        {
            Debug.Log("user failed to be found. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameF.text.Length >= 4);
    }


}
