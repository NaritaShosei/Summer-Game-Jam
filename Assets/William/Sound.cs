using System;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class Sound
{
    public string _name;
    public AudioClip _clip;
    [SerializeField, Range(0, 1)] public float _volume = 1f;
    [SerializeField] public bool _loop = true;
    [SerializeField] public bool _mute = false;


}