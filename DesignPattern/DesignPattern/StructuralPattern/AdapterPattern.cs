using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.StructuralPattern
{
    public class AdapterPattern
    {
        ///Ref: https://www.tutorialspoint.com/design_pattern/adapter_pattern.htm
        ///Adapter pattern works as a bridge between two incompatible interfaces. 
        ///This type of design pattern comes under structural pattern as this pattern combines the capability of two independent interfaces. 
        ///This pattern involves a single class which is responsible to join functionalities of independent or incompatible interfaces. 
        ///A real life example could be a case of card reader which acts as an adapter between memory card and a laptop. 
        ///You plugin the memory card into card reader and card reader into the laptop so that memory card can be read via laptop.
        
        ///We are demonstrating use of Adapter pattern via following example 
        ///in which an audio player device can play mp3 files only and wants to 
        ///use an advanced audio player capable of playing vlc and mp4 files.

        public interface IMediaPlayer
        {
            void Play(string audioType, string fileName);
        }

        public interface IAdvancedMediaPlayer
        {

            void MP4Player(string fileName);
            void VLCPlayer(string fileName);
        }

        public class MP4PlayerClass : IAdvancedMediaPlayer
        {
            public void MP4Player(string fileName)
            {
                Console.WriteLine(string.Format("AudioType: MP4, FileName: {0}", fileName));
            }
            public void VLCPlayer(string fileName)
            {
                //nothing to do
            }
        }

        public class VLCPlayerClass : IAdvancedMediaPlayer
        {
            public void MP4Player(string fileName)
            {
                //nothing to do
            }
            public void VLCPlayer(string fileName)
            {
                Console.WriteLine(string.Format("AudioType: VLC, FileName: {0}", fileName));
            }
        }

        public class MediaAdaptorClass : IMediaPlayer
        {
            IAdvancedMediaPlayer AdvancedMediaPlayer = null;
            public MediaAdaptorClass(string audioType)
            {
                if (audioType.Equals("MP4"))
                {
                    AdvancedMediaPlayer = new MP4PlayerClass();
                }
                else if (audioType.Equals("VLC"))
                {
                    AdvancedMediaPlayer = new VLCPlayerClass();
                }
            }

            public void Play(string audioType, string fileName)
            {
                if (audioType.Equals("MP4"))
                {
                    AdvancedMediaPlayer.MP4Player(fileName);
                }
                else if (audioType.Equals("VLC"))
                {
                    AdvancedMediaPlayer.VLCPlayer(fileName);
                }
            }
        }

        public class AudioPlayerClass : IMediaPlayer
        {

            MediaAdaptorClass MediaAdaptor = null;

            public void Play(string audioType, string fileName)
            {
                if (audioType.Equals("MP4") || audioType.Equals("VLC"))
                {
                    MediaAdaptor = new MediaAdaptorClass(audioType);
                    MediaAdaptor.Play(audioType,fileName);
                }
                else if (audioType.Equals("MP3"))
                {
                    Console.WriteLine(string.Format("AudioType: MP3, FileName: {0}", fileName));
                }
                else
                {
                    Console.WriteLine(string.Format("Invalid Audio Type:{0}", audioType));
                }
            }
        }

        public class AdapterPatternDemoClass
        {
            public static void AdapterPatternFunc()
            {
                AudioPlayerClass AudioPlayer = new AudioPlayerClass();

                AudioPlayer.Play("MP3","MP3Audio");
                AudioPlayer.Play("MP4", "MP4Audio");
                AudioPlayer.Play("VLC", "VLCAudio");
                AudioPlayer.Play("xxx", "xxxAudio");
            }
        }
    }
}
