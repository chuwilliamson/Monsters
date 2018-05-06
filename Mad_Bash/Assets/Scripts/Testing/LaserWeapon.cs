using UnityEngine;

public class LaserWeapon : IInteractable
{
    public LaserWeapon()    { }
    public GameObject prefab;
    public void ShootGun()
    {
        Debug.Log("Pew Pew");        
    }

    public void Interact(object token)
    {
        var sender = token as GameObject;
        if(sender == token as GameObject)
            ShootGun();

    }
}