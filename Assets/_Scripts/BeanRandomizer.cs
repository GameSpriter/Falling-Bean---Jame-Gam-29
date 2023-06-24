using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanRandomizer : MonoBehaviour
{
    [SerializeField]
    private BeanScriptableObject[] BeanSOs;

    private BeanScriptableObject NextBean;

    private void Awake()
    {
        NextBean = BeanSOs[Random.Range(0, BeanSOs.Length)];
        NextBean.InitializeBean(gameObject);
    }

    public bool Randomize(GameObject bean)
    {
        bean.GetComponent<Bean>().BeanScriptableObject = NextBean;
        NextBean.Initialize(bean);
        NextBean = BeanSOs[Random.Range(0, BeanSOs.Length)];
        NextBean.InitializeBean(gameObject);
        
        return true;
    }
}
