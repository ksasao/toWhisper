using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToWhisperNet
{
    class Program
    {
        static string inputFile;
        static string outputFile;
        static string eFile;
        static void Main(string[] args)
        {
            Whisper whisper = new Whisper();
            try
            {
                if(Initialize(args, whisper) != 0)
                {
                    return;
                }
                Wave wave = new Wave();
                wave.Read(inputFile);
                whisper.Convert(wave);
                wave.Write(outputFile, wave.Data);
                if (eFile != null)
                {
                    wave.Write(eFile, wave.EData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }

        static void PrintHelp()
        {
            Console.Write("The translating voice into whisper voice system\n");
            Console.Write("Version 0.91\n");
            Console.Write("Copyright (C) 2017 zeta\n\n");
            Console.Write("usage:\n");
            Console.Write("\ttoWhisperNet [options] [infile]\n");
            Console.Write("options:\n");
            Console.Write("\t-o : output file name.       [N/A]     [wave file]\n");
            Console.Write("\t-e : vowel sound file name.  [N/A]     [wave file]\n");
            Console.Write("\t-l : lpf filter coefficient. [0.97]    [0.0, 1.0)\n");
            Console.Write("\t-r : vowel sound rate.       [0.0]     [0.0, 1.0]\n");
            // Console.Write("\t-w : window function         [hamming] [function]\n");
            Console.Write("\t-f : frame length(ms).       [20]\n");
            Console.Write("\t-O : LPC order.              [auto]\n");
            // Console.Write("\t-p : print some information about synthesizing.\n");
            Console.Write("\t-h : print this sentence.\n");
            Console.Write("infile:\n");
            Console.Write("\twave file (MONO File only)\n");
            //Console.Write("window function name:\n");
            //Console.Write("\thamming\n\thanning\n\tblackman\n\n");
            return;
        }

        static int Initialize(string[] argv, Whisper whisper)
        {
            int count = 0;

            for (int i = 0; i < argv.Length; i++)
            {
                if (argv[i][0] != '-')
                {
                    if (count == 0)
                    {
                        inputFile = argv[i];
                    }
                    else
                    {
                        PrintHelp();
                        return -1;
                    }
                    count++;
                    continue;
                }

                switch (argv[i][1])
                {
                    case 'o':
                        i++;
                        outputFile = argv[i];
                        break;
                    case 'e':
                        i++;
                        eFile = argv[i];
                        break;
                    case 'l':
                        i++;
                        whisper.Lpf = Convert.ToDouble(argv[i]);
                        break;
                    case 'r':
                        i++;
                        whisper.Rate = Convert.ToDouble(argv[i]);
                        break;
                    //case 'w':
                    //    i++;
                    //    windowType = setWindow(argv[i]);
                    //    if (windowType == OTHER)
                    //    {
                    //        printHelp();
                    //        return -1;
                    //    }
                    //    break;
                    case 'f':
                        i++;
                        whisper.FrameT = Convert.ToDouble(argv[i]);
                        break;
                    case 'O':
                        i++;
                        whisper.Order = Convert.ToInt32(argv[i]);
                        break;
                    //case 'p':
                    //    printFlag = 1;
                    //    break;
                    case 'h':
                        PrintHelp();
                        return -1;
                    default:
                        PrintHelp();
                        return -1;
                }
            }

            if (inputFile == null)
            {
                PrintHelp();
                return -1;
            }
            if (outputFile == null)
            {
                PrintHelp();
                return -1;
            }

            return 0;
        }
    }
}
