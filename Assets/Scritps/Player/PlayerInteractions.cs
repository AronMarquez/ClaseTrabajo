using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform StarPosition;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("DeathFloor"))
        {
            //PERDER VIDA
            GameManager.Instance.LoseHealth(50);

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = StarPosition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
