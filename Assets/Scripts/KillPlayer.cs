using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterMovement>().Respawn(); //calls the respawn function in the character movement script
        }
    }
}
