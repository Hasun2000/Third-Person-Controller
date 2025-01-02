using UnityEngine;
public interface IBodyPart
{
    float DamageMultiplier { get; }
    void HandleCollision(GameObject collider);
}