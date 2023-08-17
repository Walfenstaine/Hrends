using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPK : MonoBehaviour
{
    public VariableJoystick variableJoystick;


    void Update()
    {
       Muwer.regit.muve = new Vector3(Mathf.Clamp(Input.GetAxis("Horizontal") + variableJoystick.Horizontal,-1,1), 0, Mathf.Clamp(Input.GetAxis("Vertical") + variableJoystick.Vertical,-1,1));
    }
}
