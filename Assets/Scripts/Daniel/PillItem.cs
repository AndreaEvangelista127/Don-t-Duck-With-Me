using UnityEngine;

internal class PillItem : BasePickUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public override void PickUp()
    {
        int sanity = 10;
        Debug.Log("Pill picked up! +" + sanity + " Sanity");
    }
}
