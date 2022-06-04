using Components.Common.Input;
using Leopotam.Ecs;
using UnityEngine;

namespace System.Demo
{
    public class DemoSystem : IEcsPreInitSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem, IEcsPostDestroySystem
    {
        // EcsFilter � ��� ��������, ������� ������ � ���� ������ �� Entity, ��������������� ���������� �������.
        // � ������ ������ ����� ��� ����� �������� ��� Entity, ������� ����� �� ���� AnyKeyDownTag.

        private EcsFilter<VertucalKeyDownTag> _inputFilter = null;

        public void PreInit()
        {
            //Debug.Log("PreInit is analogue Awake");
        }

        public void Init()
        {
            //Debug.Log("Init is analogue Start"); ;
        }

        public void Run()
        {
            if (!_inputFilter.IsEmpty())
            {
                Debug.Log("The button was pressed");
            }
        }

        public void Destroy()
        {
            //Debug.Log("Destroy is analogue Destroy");
        }

        public void PostDestroy()
        {
            //Debug.Log("PostDestroy are no analogues in Unity. Called after destruction");
        }

    }
}



