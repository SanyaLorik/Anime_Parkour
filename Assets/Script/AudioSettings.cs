using System.Collections.Generic;
using UnityEngine;

public class AudioSettings
{
    private readonly List<AudioSource> _sounds = new();

    private bool _isSoundPlaying = true;

    public void AddSound(AudioSource sound)
    {
        if (_isSoundPlaying == false)
            sound.Stop();

        _sounds.Add(sound);
    }

    public void TurnOn()
    {
        _isSoundPlaying = true;
        foreach (var sound in _sounds)
            sound.Play();
    }

    public void TurnOff()
    {
        _isSoundPlaying = false;
        foreach (var sound in _sounds)
            sound.Stop();
    }
}