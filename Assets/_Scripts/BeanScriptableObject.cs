using UnityEngine;

[CreateAssetMenu(fileName = "BeanScriptableObject", menuName = "ScriptableObjects/Bean")]
public class BeanScriptableObject : ScriptableObject
{
    public string Name = "BakedBean";
    public Color color = Color.red;
    public float Scale = 1.0f;

    public int Score = 3;

    public RigidbodyType2D rbType = RigidbodyType2D.Dynamic;
    public PhysicsMaterial2D rbPhysicsMaterial;
    public float rbMass = 1.0f;
    public float rbLinearDrag = 0.0f;
    public float rbAngularDrag = 0.05f;
    public float rbGravityScale = 1.0f;

    public bool Initialize(GameObject beanGameObject) {
        if (!InitializeBean(beanGameObject)) return false;
        if (!InitializeRigidBody(beanGameObject)) return false;

        return true;
    }

    public bool InitializeBean(GameObject beanGameObject)
    {
        beanGameObject.name = Name;
        beanGameObject.GetComponentInChildren<SpriteRenderer>().color = color;
        beanGameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        beanGameObject.transform.localScale *= Scale;

        return true;
    }

    public bool InitializeRigidBody(GameObject beanGameObject)
    {
        Rigidbody2D rb = beanGameObject.GetComponent<Rigidbody2D>();
        if (rb) return false;

        rb.bodyType = rbType;
        //if (rbPhysicsMaterial) rb.sharedMaterial = rbPhysicsMaterial;
        rb.mass = rbMass;
        rb.drag = rbLinearDrag;
        rb.angularDrag = rbAngularDrag;
        rb.gravityScale = rbGravityScale;

        return true;
    }

}
