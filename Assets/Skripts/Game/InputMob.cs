using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMob : MonoBehaviour
{
    public VariableJoystick variableJoystick;


    void Update()
    {
            Muwer.regit.muve = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
    }
}
