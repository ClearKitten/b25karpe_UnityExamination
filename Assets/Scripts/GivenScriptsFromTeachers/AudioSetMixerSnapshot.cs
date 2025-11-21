using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetMixerSnapshot : MonoBehaviour
{
    [Tooltip("Insert your snapshot that represents your games default settings")]
    public AudioMixerSnapshot defaultSnapshot;

    [Tooltip("Insert your snapshot that represents your games default settings")]
    public AudioMixerSnapshot situationalSnapshot;
    
    [Tooltip("How long time should it take to 'fade' between snapshots?")]
    public float transitionTime = 1f;

    public void SetSituationalSnapshot()
    {
        situationalSnapshot.TransitionTo(transitionTime);
    }

    public void SetDefaultSnapshot()
    {
        defaultSnapshot.TransitionTo(transitionTime);
    }
}
