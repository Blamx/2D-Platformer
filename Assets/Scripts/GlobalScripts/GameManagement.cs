using System.Collections;
using System.Collections.Generic;


using UnityEngine;

namespace GameManagement
{

    public class GlobalAudioManager
    {
        static private Dictionary<string, List<AudioClip>> AudioLibrary = new Dictionary<string, List<AudioClip>>();

        static public void AddToAudioLibrary(string key, List<AudioClip> clips)
        {
            AudioLibrary.Add(key, clips);
        }

        static public List<AudioClip> GetAudioClips(string key)
        {
            List<AudioClip> clips = null;

            AudioLibrary.TryGetValue(key, out clips);

            return clips;
        }

        static public AudioClip GetRandomClip(string key)
        {
            List<AudioClip> clips = null;

            AudioLibrary.TryGetValue(key, out clips);

            if (clips != null)
                return clips[Random.Range(0, clips.Count)];

            return null;
        }
    }

    public class SurfaceManager
    {
        [System.Serializable]
        public enum Surfaces { None, Grass, Rock }
    }

    public class PlayerInfo
    {
        public static Player player;
    }
}
