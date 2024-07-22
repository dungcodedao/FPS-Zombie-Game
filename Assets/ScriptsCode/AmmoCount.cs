using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text ammuntionText;
    public Text magText;

    public static AmmoCount occurrence;

    private void Awake()
    {
        occurrence = this;
    }

    public void UpdateAmmoText(int presentAmmunition)
    {
        ammuntionText.text = "Ammo. " + presentAmmunition;     
    }

    public void UpdateMagText(int mag)
    {
        magText.text = "Magazines. " + mag;
    }
}
