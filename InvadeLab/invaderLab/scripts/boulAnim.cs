using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class boulAnim : MonoBehaviour
{
    public UnityEvent onInteract;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 999999);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Animator>().Play("move");
        }
    }
}
