using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBeanSpawner : MonoBehaviour
{
    [SerializeField]
    private float SpawnTime = 0.6f;
    private float LastSpawn = 0.0f;

    [SerializeField]
    private GameObject BeanPrefab;

    [SerializeField]
    private BeanScriptableObject BeanSO;

    [SerializeField]
    private float SpawnRotation;

    private void Awake()
    {
        LastSpawn = Time.time;
    }

    private void Update()
    {
        SpawnNewBean();
    }

    private bool SpawnNewBean()
    {
        if (LastSpawn + SpawnTime > Time.time) return false;

        LastSpawn = Time.time;
        GameObject bean = Instantiate(BeanPrefab, transform.position, Quaternion.Euler(0, 0, SpawnRotation));
        Randomize(bean);

        return true;
    }

    public bool Randomize(GameObject bean)
    {
        bean.GetComponent<Bean>().BeanScriptableObject = BeanSO;
        BeanSO.Initialize(bean);
        
        return true;
    }
}
