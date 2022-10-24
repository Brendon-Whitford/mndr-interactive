using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneListener : Singleton<MicrophoneListener>
{
    //Written in part by Benjamin Outram

    public bool startMicOnStartup = true;    
    public bool stopMicrophoneListener = false;
    public bool startMicrophoneListener = false;
    public AudioMixer masterMixer;
    public bool disableOutputSound = false;
    public string volumeParamName = "MasterVolume";

    private bool microphoneListenerOn = false;
    private AudioSource audioSource;
    private float timeSinceRestart = 0;

    void Start()
    {
        //start the microphone listener
        if (startMicOnStartup)
        {
            RestartMicrophoneListener();
            StartMicrophoneListener();
        }
    }

    void Update()
    {
        if (stopMicrophoneListener)
        {
            StopMicrophoneListener();
        }
        if (startMicrophoneListener)
        {
            StartMicrophoneListener();
        }
        //reset paramters to false because only want to execute once
        stopMicrophoneListener = false;
        startMicrophoneListener = false;
        //must run in update otherwise it doesnt seem to work
        MicrophoneIntoAudioSource(microphoneListenerOn);
        //can choose to unmute sound from inspector if desired
        DisableSound(!disableOutputSound);
    }

    //stops everything and returns audioclip to null
    public void StopMicrophoneListener()
    {
        //stop the microphone listener
        microphoneListenerOn = false;
        //reenable the master sound in mixer
        disableOutputSound = false;
        //remove mic from audiosource clip
        audioSource.Stop();
        audioSource.clip = null;
        Microphone.End(null);
    }


    public void StartMicrophoneListener()
    {
        //start the microphone listener
        microphoneListenerOn = true;
        //disable sound output (dont want to hear mic input on the output!)
        disableOutputSound = true;
        //reset the audiosource
        RestartMicrophoneListener();
    }


    //controls whether the volume is on or off, use "off" for mic input (dont want to hear your own voice input!) 
    //and "on" for music input
    public void DisableSound(bool SoundOn)
    {
        float volume = 0;

        if (SoundOn)
        {
            volume = 0.0f;
        }
        else
        {
            volume = -80.0f;
        }

        masterMixer.SetFloat(volumeParamName, volume);
    }



    // restart microphone removes the clip from the audiosource
    public void RestartMicrophoneListener()
    {
        audioSource = GetComponent<AudioSource>();

        //remove any soundfile in the audiosource
        audioSource.clip = null;

        timeSinceRestart = Time.time;
    }

    //puts the mic into the audiosource
    void MicrophoneIntoAudioSource(bool MicrophoneListenerOn)
    {
        if (MicrophoneListenerOn)
        {
            //pause a little before setting clip to avoid lag and bugginess
            if (Time.time - timeSinceRestart > 0.5f && !Microphone.IsRecording(null))
            {
                audioSource.clip = Microphone.Start(null, true, 10, 44100);

                //wait until microphone position is found (?)
                while (!(Microphone.GetPosition(null) > 0))
                {
                }

                audioSource.Play(); // Play the audio source
            }
        }
    }
}
