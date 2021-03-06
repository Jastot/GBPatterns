﻿using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;


        [Header("Point")] 
        [SerializeField] private Transform _pointPosition;
        [SerializeField] private GameObject _point;
        [SerializeField] private Quaternion _rotation;
        
        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var Changingweapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            var BasicWeapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            modificationWeapon.ApplyModification(Changingweapon);
            modificationWeapon.ApplyRemoveModification(Changingweapon,BasicWeapon);
            
            var point = new Point(_point);
            modificationWeapon = new ModificationPoint(_pointPosition.position,_rotation, point);
            modificationWeapon.ApplyModification(Changingweapon);
            
            modificationWeapon.ApplyRemoveModification(Changingweapon,BasicWeapon);
            _fire = modificationWeapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}
