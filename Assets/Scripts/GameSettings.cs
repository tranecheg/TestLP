using UnityEngine;


[CreateAssetMenu(fileName = "New GameSettings")]
public class GameSettings : ScriptableObject
{
    public ForceMode forceMode;
    public float playerSpeed;
    public float shootSpeed;
    public float bulletForce;


}

