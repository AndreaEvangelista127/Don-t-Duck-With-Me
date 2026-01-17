using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp(collision);
        Destroy(gameObject);
    }

    public virtual void PickUp(Collider2D collision)
    {
        
    }
}