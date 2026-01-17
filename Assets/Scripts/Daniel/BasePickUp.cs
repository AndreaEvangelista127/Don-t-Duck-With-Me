using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp();
        Destroy(gameObject);
    }

    public virtual void PickUp()
    {
        // Basisverhalten (falls nötig)
    }
}