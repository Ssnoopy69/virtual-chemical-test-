using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentRes : MonoBehaviour
{
    
    public int res;

    public Text scr;

    public void Savsubs()
    {
        StartCoroutine(Subs());
    }

    IEnumerator Subs()
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", DBManagement.id);

        WWW www = new WWW("http://localhost/sqlconnect/students.php", form);
        yield return www;
        if (www.text == "0")
        {
            res = int.Parse(DBManagement.id) + 1;
            DBManagement.id = res.ToString();
            Debug.Log("data loaded successfully ...");
        }
        else
        {
            scr.text = www.text;
            Debug.Log("failed. Error #" + www.text);
            res = int.Parse(DBManagement.id) + 1;
            DBManagement.id = res.ToString();
        }
    }


}
