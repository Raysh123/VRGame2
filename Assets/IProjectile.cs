using UnityEngine;

public interface IProjectile
{ 
    public void HitEnemy(Collider other);
    public void Explode();
}
