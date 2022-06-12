using Components.Objects.Tags;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityComponents.MonoLinks.Base;
using UnityComponents.MonoLinks.WeaponLinks;
using UnityEngine;

namespace UnityComponents.MonoLinks
{
    public class WeaponHolderMonoLink : MonoLink<WeaponHolderTag>
{
        //public override void Make(ref EcsEntity entity)
        //{
        //    entity.Get<WeaponHolderTag>() = new WeaponHolderTag { Weapons = GetComponentsInChildren<WeaponTagMonoLink>() };
        //}
    }
}
