using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocoptNet;
using VPKAccess;
using VPKAccess.Exceptions;

namespace SoundPackConverter
{
    class Program
    {
        private const string Usage = @"Sound Pack Converter.

            Usage:
                SoundPackConverter.exe unpack <path>
                SoundPackConverter.exe (-h | --help)
                SoundPackConverter.exe --version

            Options:
                -h --help     Show this screen.
                --version     Show version.

            ";

        public static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(Usage, args, version: "Sound Pack Converter v1.0", exit: true);
            if (arguments["unpack"].IsTrue)
            {
                var pathToIndex = arguments["<path>"].ToString();

                UnpackVpk(pathToIndex);
            }
        }

        private static void UnpackVpk(string path)
        {
            Console.WriteLine("Loading VPK archive into memory.");
            Console.WriteLine("This may take a while...");
            string curDir = Path.GetDirectoryName(path);
            var file = VpkFileV1.ReadVpkV1File(path);
            int finished = 0;
            int max = file.Files.Count(x => x.FilePath.StartsWith("sounds/vo"));
            Console.WriteLine("Saving extracted file data.");
            foreach (var entry in file.Files)
            {
                if (!entry.FilePath.StartsWith("sounds/vo"))
                    continue;

                var fileDir = Path.Combine(curDir, entry.FilePath);
                if (!Directory.Exists(Path.GetDirectoryName(fileDir)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileDir));
                }

                File.WriteAllBytes(fileDir, file.GetDataForDirectoryEntry(entry));

                finished++;
                DrawProgressBar(finished, max, 20, '#');
            }
        }

        private static void UnpackVpkV2(string path)
        {

        }

        private static void DrawProgressBar(int complete, int maxVal, int barSize, char progressCharacter)
        {
            Console.CursorVisible = false;
            int left = Console.CursorLeft;
            decimal perc = (decimal)complete / (decimal)maxVal;
            int chars = (int)Math.Floor(perc / ((decimal)1 / (decimal)barSize));
            string p1 = String.Empty, p2 = String.Empty;

            for (int i = 0; i < chars; i++) p1 += progressCharacter;
            for (int i = 0; i < barSize - chars; i++) p2 += progressCharacter;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(p1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(p2);

            Console.ResetColor();
            Console.Write(" {0}%", (perc * 100).ToString("N2"));
            Console.CursorLeft = left;
        }
    }
}
