using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data/Create Player Data")]
public class PlayerDataSO : ScriptableObject
{
    public float PlayerSpeed = 10.0f;

    public float PlayerSprintMultiplier = 1.5f;

}
