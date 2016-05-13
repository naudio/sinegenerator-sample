# NAudio Sine Generator with Portamento Sample

This sample applications shows how you can generate a sine wave with portamento in NAudio. For performance it uses a wavetable to store the sine wave, allowing this technique to be easily tried with other waveforms.

The `SineWaveProvider` class implements the tone generator. The `Frequency` property selects the desired frequency. `Volume` should be set between 0.0 (silence) and 1.0 (full volume). I recommend setting the volume very low before trying this out. `PortamentoTime` adjusts the time taken to reach the target frequency. 