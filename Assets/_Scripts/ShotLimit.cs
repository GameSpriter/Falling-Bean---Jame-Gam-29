using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLimit : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text ShotTotalText;

    [SerializeField]
    private int ShotsTotal = 10;
    private int ShotsLeft;

    private void Awake()
    {
        ShotsLeft = ShotsTotal;
        UpdateShotTotalText();
    }

    public bool TakeAShot()
    {
        if (ShotsLeft <= 0) return false;
        ShotsLeft -= 1;
        UpdateShotTotalText();
        return true;
    }

    public void UpdateShotTotalText()
    {
        ShotTotalText.text = "" + ShotsLeft + " / " + ShotsTotal;
    }
}
