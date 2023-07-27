using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{   [SerializeField] float speed = 1f;
    [SerializeField] bool isEnemyLaser = false;
    void Start()
   {
       //rigidbody = GetComponent<Rigidbody>();
   }
    void Update()
    {
        if (!isEnemyLaser)
         transform.Translate(new Vector3(speed, 0f, 0f));
        else
         transform.Translate(new Vector3(-speed, 0f, 0f));
    }
}
