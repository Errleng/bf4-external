using System;
using MKO_MH4ck;
using SharpDX;

namespace MKO_MH4ck_v1_1
{
    class GPlayer
    {
        //VEHICLE
        public Int64 pAttached;
        public Int64 pVehicleEntity;
        public Int64 pDynamicPhysicsEntity;
        public Int64 pPhysicsEntity;
        public Int64 pTransform;

        public Int64 _EntityData;
        public Int64 _NameSid;
        public Int64 pAttachedClient;

        //PLAYER
        public Int64 pPlayer; //Player on the server, of course
        public Int64 pSoldier; //Soldiers are active players (Probably not commanders & spectators)
        public Int64 pHealthComponent;
        public Int64 pPredictedController;

        //WEAPON
        public Int64 pSoldierWeapon;
        public Int64 pClientWeaponComponent;
        public Int64 pWeaponHandle;
        public Int64 pWeaponEntityData;
        public Int64 pWeaponName;


        public Int64 ClientWeapon;
        public Int64 pCurrentWeaponFiring;

        public string weaponName;


        public Int64 pCorrectedFiring;
        public Int64 pPrimaryFire;
        public Int64 pShotConfigData;
        public Int64 pSway;
        public Int64 pSwayData;
        public Int64 pWeaponModifier;
        public Int64 pWeaponZeroingModifier;

        public Int64 pModes;
        public Int64 pAimingSimulation;
        public Int64 pAuthorativeAiming;
        public Int64 pViewAngles;
        public Int64 pFpsAimer;

        public string Name;
        public int Team;

        public Int64 PlayerInt;

        public Vector3 Origin;
        public Vector3 Velocity;

        public RDoll Bone;
        //public Vector3 BoneTarget;
        public int Pose;

        public Vector2 FoV;

        public Vector2 Sway;

        public int IsOccluded;
        public bool IsSpectator;

        public bool IsDriver;
        public bool InVehicle;

        public float Health;
        public float MaxHealth;

        public Gun CurrentWeapon;
        public Vehicle Vehicle;

        public float ShotsFired;
        public float ShotsHit;
        public float DamageCount;
        //public float Accuracy;

        public string LastEnemyNameAimed = "";
        public DateTime LastTimeEnimyAimed = DateTime.Now;

        public Matrix ViewProj;
        public Matrix MatrixInverse;

        //public float BreathControl;
        public bool NoBreathEnabled = false;

        public float Yaw;
        public float Pitch;
        public float Distance;
        public float DistanceToCrosshair;

        // Vehicle

        /*
        public float VehicleSpeed;
        public float VehicleWeaponHeatPercentage;
        public float VehicleRollAngle;

        public float DistanceToCrosshair;
        public float Pitch;
        public float TurretYaw;
        public float altitudeDifference;
        public float ZeroingDistanceRadians;
        */

        public bool IsValid()
        {
            return (Health > 0.1f && Health <= 100 && !Origin.IsZero);
        }

        public bool IsLegalTarget(bool bTwoSecRule, string lastTargetName, DateTime lastTimeTargeted)
        {
            return IsValid() && (!bTwoSecRule || lastTargetName == Name || DateTime.Now.Subtract(lastTimeTargeted).Seconds >= 2);
        }

        public bool IsDead()
        {
            return !(Health > 0.1f);
        }

        public bool IsVisible()
        {
           return (IsOccluded == 0);
        }

        public bool IsSprinting()
        {
            return ((float)Math.Abs(Velocity.X + Velocity.Y + Velocity.Z) > 4.0f);
        }    

        public float GetShotsAccuracy()
        {
            if ((ShotsFired > 0f && ShotsHit > 0f))
                return (float)Math.Round((double)((float)((ShotsHit / ShotsFired) * 100.0f)), 2);
            else
                return 0.0f;
        }

        public AxisAlignedBox GetAABB()
        {
            AxisAlignedBox aabb = new AxisAlignedBox();
            if (this.Pose == 0) // standing
            {
                aabb.Min = new Vector4(-0.350000f, 0.000000f, -0.350000f, 0);
                aabb.Max = new Vector4(0.350000f, 1.700000f, 0.350000f, 0);
            }
            if (this.Pose == 1) // crouching
            {
                aabb.Min = new Vector4(-0.350000f, 0.000000f, -0.350000f, 0);
                aabb.Max = new Vector4(0.350000f, 1.150000f, 0.350000f, 0);
            }
            if (this.Pose == 2) // prone
            {
                aabb.Min = new Vector4(-0.350000f, 0.000000f, -0.350000f, 0);
                aabb.Max = new Vector4(0.350000f, 0.400000f, 0.350000f,0);
            }
            return aabb;
        }
    }
}
