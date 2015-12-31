using System;
using System.IO;
using System.Linq;
using DocoptNet;
using VPKAccess;
using WPKAccess;

namespace SoundPackUnpacker
{
    class Program
    {
        private const string Usage = @"Sound Pack Unpacker.

            Usage:
                SoundPackUnpacker.exe unpack <path>
                SoundPackUnpacker.exe (-h | --help)
                SoundPackUnpacker.exe --version

            Options:
                -h --help     Show this screen.
                --version     Show version.

            ";

        public static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(Usage, args, version: "Sound Pack Unpacker v1.0", exit: true);
            if (arguments["unpack"].IsTrue)
            {
                var pathToFile = arguments["<path>"].ToString();

                var extension = Path.GetExtension(pathToFile);
                if (extension == ".vpk")
                {
                    var version = VpkFileBase.DetermineVpkFileVersion(pathToFile);
                    if (version == 1)
                        UnpackVpk(pathToFile);
                    else if (version == 2)
                        UnpackVpkV2(pathToFile);
                    else
                        Console.WriteLine("Unknown VPK file version detected. Could be an extremely old legacy file or a file too new for this unpacker.");
                }
                else if (extension == ".wpk")
                    UnpackWpk(pathToFile);
            }
        }

        private static void UnpackWpk(string pathToIndex)
        {
            Console.WriteLine("Loading WPK archive into memory.");
            string outDir = Path.Combine(Path.GetDirectoryName(pathToIndex), "WEM Output");
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);
            var wpkFile = WpkFile.ReadFile(pathToIndex);
            Console.WriteLine("Saving extracted file data.");
            foreach (var wem in wpkFile)
            {
                var wemFilePath = Path.Combine(outDir, wem.Name);
                File.WriteAllBytes(wemFilePath, wem.Data);
            }
        }

        private static void UnpackVpk(string path)
        {
            Console.WriteLine("Loading VPKv1 archive into memory.");
            string curDir = Path.GetDirectoryName(path);
            var file = VpkFileV1.ReadVpkV1File(path);
            int finished = 0;
            int max = file.Files.Count(x => x.FilePath.StartsWith("sounds/vo"));
            Console.WriteLine("Saving extracted file data.");
            Console.WriteLine("This may take a while...");
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
            Console.WriteLine("Loading VPKv2 archive into memory.");
            string curDir = Path.GetDirectoryName(path);
            var file = VpkFileV2.ReadVpkV2File(path);
            int finished = 0;
            int max = file.Files.Count(x => x.FilePath.StartsWith("sounds/vo"));
            Console.WriteLine("Saving extracted file data.");
            Console.WriteLine("This may take a while...");
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
