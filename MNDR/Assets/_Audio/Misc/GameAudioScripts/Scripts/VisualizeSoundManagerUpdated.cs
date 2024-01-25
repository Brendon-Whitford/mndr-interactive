using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VisualizeSoundManagerUpdated : Singleton<VisualizeSoundManagerUpdated> {    
    public int binNo;    
    public int sampleNo;
    public FFTWindow FFTWindow;
    public float[] binRange;
    public float[] bins;
    public float[] bins1;
    public float[] samples;
    public float decay = .35f;
   
    private float minFreq;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        samples = new float[sampleNo];
        CreateFrequencyBins();       
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.GetSpectrumData(samples, 0, FFTWindow);
        BinSamples();
        audioSource.GetSpectrumData(samples, 1, FFTWindow);
        BinSamples1();        
    }
    
    private void BinSamples()
    {
        for (int i = 0; i < binNo; i++)
        {
            bins[i] *= decay;
        }
        var bin = 0;
        for (int i = 0; i < sampleNo; i++)
        {            
            bin = BinSample(bin, i);
        }
    }

    private int BinSample(int bin, int i)
    {
        if (i * minFreq < binRange[bin])
        {
            bins[bin] += samples[i];
            return bin;
        }
        else
        {
            return BinSample(bin + 1, i);
        }
    }

    private void BinSamples1()
    {
        for (int i = 0; i < binNo; i++)
        {
            bins1[i] *= decay;
        }
        var bin = 0;
        for (int i = 0; i < sampleNo; i++)
        {
            bin = BinSample1(bin, i);
        }
    }

    private int BinSample1(int bin, int i)
    {
        if (i * minFreq < binRange[bin])
        {
            bins1[bin] += samples[i];
            return bin;
        }
        else
        {
            return BinSample1(bin + 1, i);
        }
    }

    private void CreateFrequencyBins()
    {
        var maxFreq = AudioSettings.outputSampleRate / 2.0f;
        minFreq = maxFreq / sampleNo; 
        binRange = new float[binNo];
        bins = new float[binNo];
        bins1 = new float[binNo];
        for (int i = 0; i < binNo; i++)
        {
            binRange[i] = LogSpace(minFreq, maxFreq, i, binNo);
        }
    }

    // start - start frequency
    // stop - stop frequency
    // n - the point which you wish to compute (zero based)
    // N - the number of points over which to divide the frequency
    // range.
    float LogSpace(float start, float stop, int n, int N)
    {
        return start * Mathf.Pow(stop / start, n / (float)(N - 1));
    }
}
