using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
        private AudioSource _audioSource;
        private MusicBox[] musicBox;
        private GameObject restartManager;
        
        public void Start()
        {
            restartManager = GameObject.Find("RestartManager");
            if (restartManager.GetComponent<RestartManager>().wasRestarted())
            {
                musicBox = FindObjectsOfType<MusicBox>();
                Destroy(musicBox[1].gameObject);
            }
            
        }
        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
            PlayMusic();
        }
 
        public void PlayMusic()
        {
            if (_audioSource.isPlaying) return;
            
            _audioSource.loop = true;
            _audioSource.volume = 0.15f;
            _audioSource.Play();
        }
 
        public void StopMusic()
        {
            _audioSource.Stop();
        }
}
