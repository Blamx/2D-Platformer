using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using GameManagement;

public class PlayerSoundManager : MonoBehaviour
{
    #region SoundLists

    [SerializeField, FoldoutGroup("FootSteps")]
    public List<AudioClip> FootSteps = new List<AudioClip>();

    [SerializeField, FoldoutGroup("FootSteps")]
    AudioSource FootSource;

    [SerializeField, FoldoutGroup("FootSteps")]
    float FootStepDelay = 0.2f;

    [SerializeField, FoldoutGroup("FootSteps")]
    float FootStepTimer = 0.0f;

    [SerializeField, FoldoutGroup("FootSteps")]
    float FootStepSpeed = 1.0f;


    [SerializeField, FoldoutGroup("Lands")]
    List<AudioClip> Lands = new List<AudioClip>();

    [SerializeField, FoldoutGroup("Lands")]
    AudioSource LandSource;


    [SerializeField, FoldoutGroup("Attacks")]
    List<AudioClip> Attacks1 = new List<AudioClip>();

    [SerializeField, FoldoutGroup("Attacks")]
    List<AudioClip> Attacks2 = new List<AudioClip>();

    [SerializeField, FoldoutGroup("Attacks")]
    AudioSource AttackSource;

    [SerializeField, FoldoutGroup("AttackVoice")]
    List<AudioClip> AttackVoices = new List<AudioClip>();

    [SerializeField, FoldoutGroup("AttackVoice")]
    List<AudioClip> AttackVoices2 = new List<AudioClip>();

    [SerializeField, FoldoutGroup("AttackVoice")]
    AudioSource AttackVoiceSource;

    [SerializeField, FoldoutGroup("Hurt")]
    List<AudioClip> Hurts = new List<AudioClip>();

    [SerializeField, FoldoutGroup("Hurt")]
    AudioSource HurtSource;

    [SerializeField, FoldoutGroup("Jump")]
    List<AudioClip> Jumps = new List<AudioClip>();

    [SerializeField, FoldoutGroup("Jump")]
    AudioSource JumpSource;

    [SerializeField, FoldoutGroup("Bow")]
    List<AudioClip> Bows = new List<AudioClip>();

    [SerializeField, FoldoutGroup("Bow")]
    AudioSource BowSource;

    [SerializeField, FoldoutGroup("Fall")]
    AudioSource FallSource;

    #endregion


    Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (FootStepTimer > 0)
        {
            FootStepTimer -= Time.deltaTime * FootStepSpeed;
        }
    }

    public void PlayFootStep(float SpeedMod)
    {
        if (FootStepTimer <= 0)
        {
            FootStepTimer = FootStepDelay;
            FootStepSpeed = SpeedMod;
            FootSource.clip = GlobalAudioManager.GetRandomClip(player.CurrentSurface.ToString() + "_Foot");
            FootSource.Play();
        }
    }

    public void PlayLand()
    {
        LandSource.clip = GlobalAudioManager.GetRandomClip(player.CurrentSurface.ToString() + "_Land");
        LandSource.Play();
    }

    public void PlayAttack(int Combo)
    {
        if(Combo <= 1)
        {
            AttackSource.clip = Attacks1[Random.Range(0, Attacks1.Count)];
            AttackSource.Play();
        }
        else
        {
            AttackSource.clip = Attacks2[Random.Range(0, Attacks2.Count)];
            AttackSource.Play();
        }
    }

    public void PlayAttackVoice(int Combo)
    {
        if (Combo <= 1)
        {
            AttackVoiceSource.clip = AttackVoices[Random.Range(0, AttackVoices.Count)];
            AttackVoiceSource.Play();
        }
        else
        {
            AttackVoiceSource.clip = AttackVoices2[Random.Range(0, AttackVoices2.Count)];
            AttackVoiceSource.Play();
        }
    }

    public void PlayHurt()
    {
        HurtSource.clip = Hurts[Random.Range(0, Hurts.Count)];
        HurtSource.Play();
    }

    public void PlayJump()
    {
        JumpSource.clip = Jumps[Random.Range(0, Jumps.Count)];
        JumpSource.Play();
    }

    public void PlayBow()
    {
        BowSource.clip = Bows[Random.Range(0, Bows.Count)];
        BowSource.Play();
    }

    public void PlayFall()
    {
        if(!FallSource.isPlaying)
        FallSource.Play();
    }

    public void StopFall()
    {
        if (FallSource.isPlaying)
            FallSource.Stop();
    }

}
