using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class Salasand : FishBehavior
{

    public void Start()
    {
        isReadyToBeCaught = true;
    }

    public void PlaySalasandJump()
    {
        AudioSource audioSource = GetComponent <AudioSource>();
        AudioManager.Instance.PlaySound( 4, audioSource);
    }
    public void PlaySalasandMoves()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        int[] soundsIdsSand = { 6, 7, 8 };
        int randomIndexSand = Random.Range(0, soundsIdsSand.Length);
        int randomSoundIdSand = soundsIdsSand[randomIndexSand];
        AudioManager.Instance.PlaySound( 3, audioSource);
    }

public void PlaySalasandDive()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.PlaySound(3, audioSource);
    }
}
