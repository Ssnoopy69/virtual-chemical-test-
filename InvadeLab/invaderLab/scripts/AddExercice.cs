using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddExercice : MonoBehaviour
{
    public InputField quest;
    public InputField repone;
    public InputField reptwo;
    public InputField repthree;

    public Button submitButton;

    public void CallAdd()
    {
        StartCoroutine(Addit());
    }

    IEnumerator Addit()
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", DBManagement.userid);
        form.AddField("quest", quest.text);
        form.AddField("repone", repone.text);
        form.AddField("reptwo", reptwo.text);
        form.AddField("repthree", repthree.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("exer added successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("exer adding failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (quest.text.Length >= 10 && repone.text.Length >= 9 && reptwo.text.Length >= 8);
    }
}
