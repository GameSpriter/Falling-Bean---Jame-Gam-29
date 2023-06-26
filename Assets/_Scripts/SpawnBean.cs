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
        GetComponentInChildren<DrawDragLine>().StartLineDraw();
    }

    private void MouseUp()
    {
        float distance = Vector3.Distance(mouseStartingPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (distance > DrawDistanceMax) distance = DrawDistanceMax;
        if (distance < 0) distance = 0;
        float forcePerUnit = (ForceMax - ForceMin) / DrawDistanceMax;
        float finalForce = (forcePerUnit * distance) + ForceMin;
        SpawnNewBean(finalForce * (mouseStartingPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized);
        
        GetComponentInChildren<DrawDragLine>().EndLineDraw();
    }

    private bool SpawnNewBean(Vector2 force)
    {
        if (LastSpawn + SpawnTime > Time.time) return false;
        if (!LevelController.Singleton.GetComponent<ShotLimit>().TakeAShot()) return false;

        LastSpawn = Time.time;
        GameObject bean = Instantiate(BeanPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
        GetComponent<BeanRandomizer>().Randomize(bean);

        bean.GetComponent<Rigidbody2D>().AddForce(force);

        return true;
    }
    
}
