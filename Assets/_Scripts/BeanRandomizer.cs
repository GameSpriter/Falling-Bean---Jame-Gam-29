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
        RandomizeNextBean();
        NextBean.InitializeBean(gameObject);
        
        return true;
    }

    private bool RandomizeNextBean()
    {
        BeanScriptableObject lastBean = NextBean;
        NextBean = BeanSOs[Random.Range(0, BeanSOs.Length)];

        if(lastBean.Name == NextBean.Name) RandomizeNextBean();

        return true;
    }
}
