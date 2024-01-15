using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{

    public GameObject Bala;
    public GameObject CanoDaArma;
    public bool comArma = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per framepublic float velocidadeRotacao = 30f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && comArma)
       {
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
       }

    }

    public void alterarArmado(bool novoValor)
    {
        comArma = novoValor;
    }
}

