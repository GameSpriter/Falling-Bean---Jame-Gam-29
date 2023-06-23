using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBean : MonoBehaviour
{
    [SerializeField]
    private float SpawnTime = 0.5f;
    private float LastSpawn = 0.0f;

    [SerializeField]
    private GameObject BeanPrefab;

    [SerializeField]
    private int ForceMin;

    [SerializeField]
    private int ForceMax;

    [SerializeField]
    private float VerticalForcePercentage;

    private void Awake()
    {
        LastSpawn = Time.time;
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (LastSpawn + SpawnTime > Time.time) return;

        LastSpawn = Time.time;
        GameObject bean = Instantiate(BeanPrefab, transform.position, Quaternion.identity);
        bean.GetComponent<Rigidbody2D>().AddForce(
            Vector2.right * Random.Range(ForceMin, ForceMax) 
            + Vector2.up * Random.Range(ForceMin, ForceMax) * VerticalForcePercentage
        );

        GetComponent<BeanRandomizer>().Randomize(bean);
    }
}
