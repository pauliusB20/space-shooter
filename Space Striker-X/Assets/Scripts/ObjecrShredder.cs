using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecrShredder : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherObject)
    {
        Destroy(otherObject.gameObject);
    }
}
