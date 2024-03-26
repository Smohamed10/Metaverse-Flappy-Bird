using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlescript : MonoBehaviour
{
    public LogicMangerScript mangerScript;
    // Start is called before the first frame update
    void Start()
    {
        mangerScript=GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMangerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mangerScript.addscore();
    }
}
