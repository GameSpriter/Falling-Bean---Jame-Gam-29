using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanRandomizer : MonoBehaviour
{
    [SerializeField]
    private BeanScriptableObject[] BeanSOs;

    public bool Randomize(GameObject bean)
    {
        BeanScriptableObject bso = BeanSOs[Random.Range(0, BeanSOs.Length)];
        bean.GetComponentInChildren<SpriteRenderer>().color = bso.color;
        bean.name = bso.Name;

        return true;
    }
}
