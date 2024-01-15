using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    private Rigidbody rigidBodyBala;
    public float velocidade = 30;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyBala = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBodyBala.MovePosition (rigidBodyBala.position + 
            transform.forward * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if(objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }    

        Destroy(gameObject);
        
    }
}
