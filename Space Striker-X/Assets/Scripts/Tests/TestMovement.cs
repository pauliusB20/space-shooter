using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;
public class TestMovement : MonoBehaviour
{
  [SerializeField] float speed = 2f;

  protected Joystick joystick;
  protected Button button;

  void Awake()
  {
      joystick = FindObjectOfType<Joystick>();
      button = FindObjectOfType<Button>();
  }
  void Update()
  {
      transform.position =
       new Vector3(transform.position.x + joystick.AxisNormalized.x * Time.deltaTime * speed, 
                   transform.position.y  + joystick.AxisNormalized.y * Time.deltaTime * speed,
                   transform.position.z);
  }

 /* int btnCounter = 1;
  Rigidbody rigidbody;

  void Start()
  {
      rigidbody = GetComponent<Rigidbody>();
  }

  public void moveRight()
  {
      rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);
      btnCounter++;
      if (btnCounter % 2 == 0)
        rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, rigidbody.velocity.z);
  }
  public void moveLeft()
  {
      rigidbody.velocity = new Vector3(-speed, rigidbody.velocity.y, rigidbody.velocity.z);
      btnCounter++;
      if (btnCounter % 2 == 0)
        rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, rigidbody.velocity.z);
  }*/
}
