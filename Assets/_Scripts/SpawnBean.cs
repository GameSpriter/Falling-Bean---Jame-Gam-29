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
    private int DrawDistanceMax;

    [SerializeField]
    private float VerticalForcePercentage;

    private Vector3 mouseStartingPosition;

    private void Awake()
    {
        LastSpawn = Time.time;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) MouseDown();
        if (Input.GetMouseButtonUp(0)) MouseUp();
    }

    private void MouseDown()
    {
        mouseStartingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void MouseUp()
    {
        float distance = Vector3.Distance(mouseStartingPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (distance > DrawDistanceMax) distance = DrawDistanceMax;
        if (distance < 0) distance = 0;
        float forcePerUnit = (ForceMax - ForceMin) / DrawDistanceMax;
        float finalForce = (forcePerUnit * distance) + ForceMin;
        SpawnNewBean(finalForce);
    }

    private bool SpawnNewBean(float force)
    {
        if (LastSpawn + SpawnTime > Time.time) return false;

        LastSpawn = Time.time;
        GameObject bean = Instantiate(BeanPrefab, transform.position, Quaternion.identity);
        GetComponent<BeanRandomizer>().Randomize(bean);

        bean.GetComponent<Rigidbody2D>().AddForce(
            Vector2.right * force 
            + Vector2.up * force * VerticalForcePercentage
        );

        return true;
    }
}
