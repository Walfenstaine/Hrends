using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Door_MRom door;
    public DoorExit exit;
    public KeyOfTipe tipe;
    public enum KeyOfTipe {Room, Exit}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (tipe == KeyOfTipe.Room)
            {
                door.activate = true;
            }
            else {
                exit.activate = true;
            }
            Destroy(gameObject);
        }
    }
}
