using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MKO_MH4ck_v1_1;
using SharpDX;

namespace MKO_MH4ck
{
    class Vehicle
    {
        //Vehicle Weapon
        public Gun VehicleGun;

        public Vector3 Velocity;
        public Vector3 Center;

        public Vector3 Crosshair;

        public string Name;

        public AxisAlignedBox AABB;
        public Matrix Transform;
        public Matrix Shootspace;
        public float Health;
        public float MaxHealth;

        public Int64 PrimaryFire;
        public Int64 ShotConfigData;
        public Int64 ProjectileData;
    }
}
