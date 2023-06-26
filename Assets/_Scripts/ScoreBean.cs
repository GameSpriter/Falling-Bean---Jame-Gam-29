using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBean : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bean")) return;

        Destroy(other.gameObject);

        if (!ScoreController.Singleton) Debug.Log("No available Score Controller");
        ScoreController.Singleton.AddScore(other.gameObject.GetComponent<Bean>().BeanScriptableObject.Score);
    }
}
