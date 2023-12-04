using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;
    private float[] _samplesLeft = new float[512];
    private float[] _samplesRight = new float[512];

    private float[] _freqBand = new float[8];
    private float[] _bandBuffer = new float[8];
    private float[] _bufferDecrease = new float[8];
    private float[] _freqBandHighest = new float[8];

    //Audio 64
    private float[] _freqBand64 = new float[64];
    private float[] _bandBuffer64 = new float[64];
    private float[] _bufferDecrease64 = new float[64];
    private float[] _freqBandHighest64 = new float[64];

    //[HideInInspector]
    public float[] _audioBand, _audioBandBuffer;

    [HideInInspector]
    public float[] _audioBand64, _audioBandBuffer64;

    [HideInInspector]
    public float _amplitude, _amplitudeBuffer;
    public static bool _micIsSilent;
    private float _amplitudeHighest;
    public float _audioProfile;

    public enum _channel {Stereo, Left, Right};
    public _channel channel = new _channel();

    // Start is called before the first frame update
    void Start()
    {
        _audioBand = new float[8];
        _audioBandBuffer = new float[8];

        _audioBand64 = new float[64];
        _audioBandBuffer64 = new float[64];

        _audioSource = GetComponent<AudioSource>();
        AudioProfile(_audioProfile);
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();

        //audio64
        MakeFrequencyBands64();
        BandBuffer64();
        CreateAudioBands64();

    }

    void AudioProfile(float audioProfile)
    {
        for (int i = 0; i < 8; i++)
        {
            _freqBandHighest[i] = audioProfile; 
        }
    }

    void GetAmplitude()
    {
        float _currentAmplitude = 0;
        float _currentAmplitudeBuffer = 0;

        for (int i = 0; i < 8; i++)
        {
            _currentAmplitude += _audioBand[i];
            _currentAmplitudeBuffer += _audioBandBuffer[i];
        }

        if (_currentAmplitude > _amplitudeHighest)
        {
            _amplitudeHighest = _currentAmplitude;
        }

        _amplitude = _currentAmplitude / _amplitudeHighest;
        _amplitudeBuffer = _currentAmplitudeBuffer / _amplitudeHighest;
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }

            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);

            if (_micIsSilent)
            {
                _audioBandBuffer[i] = 0;
            }

            else
            {
                _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
            }
        }
    }

    void CreateAudioBands64()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand64[i] > _freqBandHighest64[i])
            {
                _freqBandHighest64[i] = _freqBand64[i];
            }

            _audioBand64[i] = (_freqBand64[i] / _freqBandHighest64[i]);

            if (_micIsSilent)
            {
                _audioBandBuffer64[i] = 0;
            }

            else
            {
                _audioBandBuffer64[i] = (_bandBuffer64[i] / _freqBandHighest64[i]);
            }
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samplesLeft, 0, FFTWindow.Blackman);
        _audioSource.GetSpectrumData(_samplesRight, 1, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.0005f;
            }

            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void BandBuffer64()
    {
        for (int g = 0; g < 8; g++)
        {
            if (_freqBand64[g] > _bandBuffer64[g])
            {
                _bandBuffer64[g] = _freqBand64[g];
                _bufferDecrease64[g] = 0.0005f;
            }

            if (_freqBand64[g] < _bandBuffer64[g])
            {
                _bandBuffer64[g] -= _bufferDecrease64[g];
                _bufferDecrease64[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        /*
         * 22050 / 512 = ~43hz per sample
         * 
         * 20 - 60hz
         * 60 - 250hz
         * 250 - 500hz
         * 500 - 2000hz
         * 2000 - 4000hz
         * 4000 - 6000hz
         * 6000 - 2000hz
         * 
         * 0: 2 samples, 86hz
         * 1: 4 samples, 172hz, 87 - 258hz
         * 2: 8 samples, 344hz, 259 - 602hz
         * 3: 16 samples, 688hz, 603 - 1290hz
         * 4: 32 samples, 1376hz, 1291 - 2666hz
         * 5: 64 samples, 2752hz, 2667 - 5418hz
         * 6: 128 samples, 5504hz, 5419 - 10922hz
         * 7: 256 samples, 110008hz, 10923 - 21930hz
         * = 510 samples
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2; // makes up for the missing 2 samples
            }

            for (int j = 0; j < sampleCount; j++)
            {
                if (channel == _channel.Stereo)
                {
                    average += (_samplesLeft[count] + _samplesRight[count]) * (count + 1);
                }

                if (channel == _channel.Left)
                {
                    average += _samplesLeft[count] * (count + 1);
                }

                if (channel == _channel.Right)
                {
                    average += _samplesRight[count] * (count + 1);
                }
                
                count++;
            }

            average /= count;
            _freqBand[i] = average * 10;

        }
    }
    void MakeFrequencyBands64()
    {
        
        int count = 0;
        int sampleCount = 1;
        int power = 0;

        for (int i = 0; i < 64; i++)
        {
            float average = 0;
            
            if (i == 16 || i == 32 || i == 40 || i == 48 || i == 56 )
            {
                sampleCount = (int)Mathf.Pow(2, power) * 2;
                power++;

                if (power == 3)
                {
                    sampleCount -= 2;
                }
            }

            for (int j = 0; j < sampleCount; j++)
            {
                if (channel == _channel.Stereo)
                {
                    average += (_samplesLeft[count] + _samplesRight[count]) * (count + 1);
                }

                if (channel == _channel.Left)
                {
                    average += _samplesLeft[count] * (count + 1);
                }

                if (channel == _channel.Right)
                {
                    average += _samplesRight[count] * (count + 1);
                }

                count++;
            }

            average /= count;
            _freqBand64[i] = average * 8;

        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
