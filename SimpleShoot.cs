using UnityEngine;
using Valve.VR;

public class SimpleShoot : ShootWeapon  
{
    void Update()
    {
        if ((SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand)) && Time.time >= nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + 10f / fireRate;
            GetComponent<Animator>();
            Shoot();
            Bullet();
            Audio();
            CasingRelease();
        }
    }
}