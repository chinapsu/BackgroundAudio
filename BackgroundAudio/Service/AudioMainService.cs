using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackgroundAudio.Service
{
    class AudioMainService
    {
        NAudio.Wave.WaveInEvent wavein = null;
        NAudio.Wave.WaveFileWriter writer = null;
        NAudio.Wave.WaveOutEvent waveout = null;
        NAudio.Wave.BufferedWaveProvider bufferedWaveProvider = null;
        Codec.INetworkChatCodec networkCode = null;
        public AudioMainService()
        {
            //networkCode = new Codec.NarrowBandSpeexCodec(); //8k Bit
            //networkCode = new Codec.WideBandSpeexCodec();//16k Bit
            networkCode = new Codec.UltraWideBandSpeexCodec(); //32k Bit
        }

        internal void Start()
        {
            wavein = new NAudio.Wave.WaveInEvent();
            //wavein.WaveFormat = new NAudio.Wave.WaveFormat(2 * 8000, 1);
            wavein.WaveFormat = networkCode.RecordFormat;
            wavein.DataAvailable += Wavein_DataAvailable;

            //同时写出到文件
            writer = new NAudio.Wave.WaveFileWriter(Path.Combine("c:\\", DateTime.Now.ToString("hh_MM_ss.wav")), wavein.WaveFormat);
            //同时播放
            waveout = new NAudio.Wave.WaveOutEvent();
            bufferedWaveProvider = new NAudio.Wave.BufferedWaveProvider(networkCode.RecordFormat);
            try
            {
                waveout.Init(bufferedWaveProvider);
                waveout.Play();
            }
            catch { Console.WriteLine("启动外放失败，可能当前无可用播放设备！"); }
            //开始录音
            try
            {
                wavein.StartRecording();
            }
            catch { Console.WriteLine("启动录音失败，可能当前无可用录音设备！"); }
        }

        private void Wavein_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            //接收到的大文件
            byte[] encoded = networkCode.Encode(e.Buffer, 0, e.BytesRecorded);
            //将encoded的进行网络传送。
            var bytes = networkCode.Decode(encoded, 0, encoded.Length);
            //写出到文件
            writer.Write(bytes, 0, bytes.Length);
            //播放
            bufferedWaveProvider.AddSamples(bytes, 0, bytes.Length);
        }

        internal void Stop()
        {
            wavein.StopRecording();
            wavein.Dispose();
            writer.Dispose();
            waveout.Stop();
            waveout.Dispose();
        }
    }
}
