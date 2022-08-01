using Components.Objects.Tags;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using Systems.CoreSystems.Shooting;
using UnityComponents.MonoLinks.Base;
using UnityComponents.MonoLinks.WeaponLinks;
using UnityEngine;

namespace UnityComponents.MonoLinks
{
    public class WeaponHolderMonoLink : MonoLink<WeaponHolderLink>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<WeaponHolderLink>() = new WeaponHolderLink { Value = gameObject.GetComponent<WeaponHolderMonoEntity>() };
        }
    }
}
