using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bookquest : MonoBehaviour
{
    public GameObject txtToDisplay;

    private bool PlayerInZone;

    public Text quest;
    public Text answero;
    public Text answert;
    public Text answerth;

    private void Start()
    {
        PlayerInZone = false;                   //player not in zone       
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.F))           //if in zone and press F key
        {
            txtToDisplay.SetActive(true);
            Selquest();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }

    public void Selquest()
    {
        StartCoroutine(Subs());
    }

    IEnumerator Subs()
    {
        WWWForm form = new WWWForm();
        form.AddField("profuname", DBManagement.profuname);

        WWW www = new WWW("http://localhost/sqlconnect/bookquest.php", form);
        yield return www;
        if (www.text != "0")
        {
            string input = www.text;
            int i = input.IndexOf('.');
            int j = input.IndexOf('.');
            int k = input.IndexOf('.');
            int l = input.IndexOf('.');
            string result = input.Substring(0, i + 1);
            string repone = input.Substring(i + 1, j + 1);
            string reptwo = input.Substring(j + 1, k + 1);
            string repthree = input.Substring(k + 1, l + 1);
            quest.text = result;
            answero.text = repone;
            answert.text = reptwo;
            answerth.text = repthree;
            Debug.Log("data loaded successfully ...");
        }
        else
        {
            Debug.Log("failed. Error #" + www.text);
        }

    }

    
}
