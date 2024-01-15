using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject ArmaOnPlayer;

    public ControlaArma controlaArma;

    void Update()
    {
        transform.Rotate(0f, 60f * Time.deltaTime, 0f, Space.Self);
    }

    // Start is called before the first frame update
    void Start()
    {
        ArmaOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                controlaArma.alterarArmado(true);
                this.gameObject.SetActive(false);
                PickUpText.SetActive(false);
                ArmaOnPlayer.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
