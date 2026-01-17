using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp();
        Destroy(gameObject);
    }

    public virtual void PickUp()
    {
        
    }
}