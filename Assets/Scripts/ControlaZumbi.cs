using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    private Rigidbody rigidBodyInimigo;
    public float Velocidade = 5;
    public GameObject Jogador;

    private Animator animatorZumbi;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyInimigo = GetComponent<Rigidbody>();
        Jogador = GameObject.FindWithTag("Player");
        animatorZumbi = GetComponent<Animator>();
        animatorZumbi.SetBool("Acertado", false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcao = Jogador.transform.position - transform.position;
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

        rigidBodyInimigo.MoveRotation(novaRotacao);

        if(distancia > 2.5)
        {
            rigidBodyInimigo.MovePosition(rigidBodyInimigo.position + direcao.normalized * Velocidade * Time.deltaTime);
            animatorZumbi.SetBool("PlayerPerto", false);
        }
        else
        {
            animatorZumbi.SetBool("PlayerPerto", true);
        }
    }

    public void MorreZumbi()
    {
        animatorZumbi.SetBool("Acertado", true);
    }
}
