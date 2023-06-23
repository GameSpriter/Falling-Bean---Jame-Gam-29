using UnityEngine;

[CreateAssetMenu(fileName = "BeanScriptableObject", menuName = "ScriptableObjects/Bean")]
public class BeanScriptableObject : ScriptableObject
{
    public string Name = "BakedBean";
    public Color color = Color.red;

    public int Score = 3;

}
