using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesComplete : MonoBehaviour
{
    [Header("Objectives to Complete")]
    public Text objectives1;
    public Text objectives2;
    public Text objectives3;
    public Text objectives4;

    public static ObjectivesComplete occurence;

    private void Awake()
    {
        occurence = this;
    }

    public void GetObjectivesDone(bool obj1, bool obj2, bool obj3, bool obj4)
    {
        if (obj1 == true)
        {
            objectives1.text = "1. Completed";
            objectives1.color = Color.green;
        }
        else
        {
            objectives1.text = "01. Find The Rifle";
            objectives1.color = Color.white;
        }

        if (obj2 == true)
        {
            objectives2.text = "2. Completed";
            objectives2.color = Color.green;
        }
        else
        {
            objectives2.text = "02. Locate The Villageres";
            objectives2.color = Color.white;
        }

        if (obj3 == true)
        {
            objectives3.text = "3. Completed";
            objectives3.color = Color.green;
        }
        else
        {
            objectives3.text = "03. Find Vehicle";
            objectives3.color = Color.white;
        }

        if (obj4 == true)
        {
            objectives4.text = "3. Mission Completed";
            objectives4.color = Color.green;
        }
        else
        {
            objectives4.text = "04. Get All Villagers into vehicle";
            objectives4.color = Color.white;
        }
    }
}
