using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class AudioPeerC : MonoBehaviour
{
    AudioSource _audioSource;
    public float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if(_freqBand [g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if(_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        // 22050 / 512 = 43 hertz per sample
        //20 - 60 hertz
        //60 - 250 hertz
        //250 - 500 hertz
        //500 - 2000 hertz
        //2000 - 4000 hertz
        //4000 - 6000 hertz
        //6000 - 20000hertz

        //0 - 2 = 86 hertz
        //1 - 4 = 172 hertz range of 87 - 258 hertz
        //2 - 8 = 344hertz range of 259 - 602 hertz
        //3
        //4
        //5
        //6
        //7

        int count = 0;
        for (int l = 0; l < 8; l++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, l) * 2;

            if (l == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                    count++;
            }
            average /= count;
            _freqBand[l] = average * 10;
        }
    }
}
