using UnityEngine;
using Valve.VR;

public class AkShot : ShootWeapon
{
    void Update()
    {
        if ((SteamVR_Actions._default.GrabPinch.GetState(SteamVR_Input_Sources.RightHand))&& Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 2f / fireRate;
            Shoot();
            Bullet();
            Audio();
            CasingRelease();
        }
    }
}