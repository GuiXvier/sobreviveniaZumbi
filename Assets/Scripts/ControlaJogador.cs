using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    private Rigidbody rigidBodyJogador;
    private Animator animatorJogador;
    private Vector3 direcao;

    public float Velocidade = 10;

    public LayerMask MascaraChao;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Vertical");
        float eixoY = Input.GetAxis("Horizontal");

        direcao = new Vector3(eixoX, 0, eixoY);

        if (direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            animatorJogador.SetBool("Movendo", false);
        }
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        rigidBodyJogador.MovePosition(rigidBodyJogador.position +
             (direcao * Velocidade * Time.fixedDeltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidBodyJogador.MoveRotation(novaRotacao);
        }
    }
}
