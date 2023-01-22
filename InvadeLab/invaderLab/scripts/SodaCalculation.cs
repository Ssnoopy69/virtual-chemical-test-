using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SodaCalculation : MonoBehaviour
{
    public InputField inputNml;
    public InputField inputNaoh;
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
        form.AddField("volsoud", inputNml.text);
        form.AddField("volsoda", inputNaoh.text);
        form.AddField("massres", textRes.text);
        
        WWW www = new WWW("http://localhost/sqlconnect/sodaSubs.php", form);
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
        float res = ((int.Parse(inputNml.text)) * (int.Parse(inputNaoh.text)) * (Mathf.Pow(10, -3)) * (Mathf.Pow(10, -2))) * (Mathf.Pow(10, 3));
        formprin.text = "M(NaOH) × V × C(NaOH)";
        formuleq.text = inputNml.text + " x " + inputNaoh.text + " x 10^-3 x 0,01";
        textRes.text = res.ToString() + " mg";
        uIobjD.SetActive(false);
        plActv.SetActive(true);
    }



}
