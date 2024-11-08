using System;

public enum WeaponTypes { Mashinegun, Shotgun, Flamer, Plasmagun };

[Serializable]

public struct WeaponAmmo
{
    public WeaponTypes type;
    public int ammo;
}