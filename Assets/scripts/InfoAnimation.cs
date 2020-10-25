using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Text texto;
    float contador = 0.0f;


    void Start()
    {
        texto = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador % 1.0f;
        if(contador < 0.5f)
        {
            texto.enabled = true;
        }
        else
        {
            texto.enabled = false;
        }
        contador += Time.deltaTime;
    }
}
