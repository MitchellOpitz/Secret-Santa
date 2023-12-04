using UnityEngine;

public class ControllerButtonDebugger : MonoBehaviour
{
    void Update()
    {
        string[] buttonNames = Input.GetJoystickNames();

        foreach (string joystickName in buttonNames)
        {
            for (int i = 0; i < 20; i++) // Assuming a maximum of 20 buttons, adjust as needed
            {
                string buttonName = "joystick " + joystickName + " button " + i;

                if (Input.GetButtonDown(buttonName))
                {
                    Debug.Log("Button pressed: " + buttonName);
                }
            }
        }
    }
}
