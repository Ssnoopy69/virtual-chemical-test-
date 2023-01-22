using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Acidcalculation : MonoBehaviour
{
    public InputField inputkav;
    public InputField inputkap;
    public Text formprin;
    public Text formuleq;
    public Text textRes;

    public GameObject plActv;
    public GameObject uIobjD;

    public void Savsubs()
    {
        StartCoroutine(Subs());
    }

    IEnumerator Subs()
    {
        WWWForm form = new WWWForm();
        form.AddField("uname", DBManagement.username);
        form.AddField("uid", DBManagement.userid);
        form.AddField("acid", "fluohydrique");
        form.AddField("valka", inputkav.text);
        form.AddField("puis", inputkap.text);
        form.AddField("pka", textRes.text);

        WWW www = new WWW("http://localhost/sqlconnect/acidcalc.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("data saved successfully ...");
        }
        else
        {
            Debug.Log("failed. Error #" + www.text);
        }
    }

    public void CallSubs()
    {
        double res = ((double.Parse(inputkav.text)) * Math.Pow(10, -(int.Parse(inputkap.text))));
        double resp = Math.Log(res * (-1));
        formprin.text = "HA + H2O        H3O+ + A-";
        formuleq.text = "Ka = ([H3O+]x[A-]) / [HA]";
        textRes.text = "Ka = " + res.ToString() + "pKa = -log(Ka) = " + resp.ToString();
        uIobjD.SetActive(false);
        plActv.SetActive(true);
    }



}
