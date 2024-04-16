using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    public Animator door;

    private void OnTriggerEnter(Collider other)
    {
        door.Play("door_2_open");
    }

    private void OnTriggerExit(Collider other)
    {
        door.Play("door_2_close");
    }

}
