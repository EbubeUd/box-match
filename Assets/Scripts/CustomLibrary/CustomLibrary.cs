using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * CustomLibrary class defines custom methods that perform utility functions
 */
public class CustomLibrary : MonoBehaviour
{
    // Returns true if the user is not currently providing any input, returns false otherwise
    public static bool NoInputIsDetected()
    {
        return !InputIsDetected();
    }


    // Returns true if the user is currently providing some input, returns false otherwise
    public static bool InputIsDetected()
    {
        return MouseInputIsDetected() || TouchInputIsDetected();
    }


    // Returns the screen positions where the user is currently providing input
    public static Vector2[] GetInputPositions()
    {
        Vector2[] inputPositions = new Vector2[0];

        if (MouseInputIsDetected()) {
            inputPositions = GetMousePosition();
        }
        else if (TouchInputIsDetected()) {
            inputPositions = GetTouchPositions();
        }

        return inputPositions;
    }


    // Returns the screen position where the user is currently providing mouse input
    private static Vector2[] GetMousePosition()
    {
        Vector2[] mousePosition = new Vector2[1];
        mousePosition[0] = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }


    // Returns the screen position(s) where the user is currently providing touch input
    private static Vector2[] GetTouchPositions()
    {
        Vector2[] touchPositions = new Vector2[Input.touchCount];

        for (int i = 0; i < Input.touchCount; i++) {
            touchPositions[i] = (Vector2) Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
        }

        return touchPositions;
    }


    // Returns true if the user is currently providing mouse input, returns false otherwise
    private static bool MouseInputIsDetected()
    {
        const int PRIMARY_MOUSE_BUTTON = 0;
        return Input.mousePresent && Input.GetMouseButtonDown(PRIMARY_MOUSE_BUTTON);
    }


    // Returns true if the user is currently providing touch input, returns false otherwise
    private static bool TouchInputIsDetected()
    {
        return Input.touchSupported && Input.touchCount > 0;
    }
}
