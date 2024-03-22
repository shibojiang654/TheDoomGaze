using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    #region Variables
    public GameObject door;
    private int boxesOnPlate = 0;
    #endregion

    #region Trigger Events
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            boxesOnPlate++;
            Debug.Log("Box entered pressure plate. Boxes on this plate: " + boxesOnPlate);

            if (AllPlatesActivated())
            {
                Debug.Log("All pressure plates activated. Unlocking door.");
                Destroy(door);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            boxesOnPlate--;
            Debug.Log("Box exited pressure plate. Boxes on this plate: " + boxesOnPlate);
        }
    }
    #endregion

    #region Helper Methods
    private bool AllPlatesActivated()
    {
        PressurePlate[] pressurePlates = FindObjectsOfType<PressurePlate>();

        foreach (PressurePlate plate in pressurePlates)
        {
            if (plate.boxesOnPlate == 0)
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}