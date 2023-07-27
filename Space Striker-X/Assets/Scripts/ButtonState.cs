using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonState : MonoBehaviour
{
    [SerializeField] bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
   
    public void onHold()
    {
       isPressed = true;
    }
    public void OnRelease(){
       isPressed = false;
    }
    public bool Pressed()
    {
        return isPressed;
    }
    
}
