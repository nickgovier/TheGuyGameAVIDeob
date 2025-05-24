using System;
using System.IO;

class TheGuyGameAVIDeob
{
    public static void Main(String[] args)
    {
        string path = "C:\\Path To\\The Guy Game\\Final\\Video";

        List<string> files = new List<string>();
        ListAviFiles(path, ref files);

        foreach(string file in files)
        {
            Console.WriteLine(file);

            ReplaceBytes(file, new (long, byte)[]
            {
                (0x00000000, 0x52),
                (0x00000001, 0x49),
                (0x00000002, 0x46),
                (0x00000003, 0x46),

                (0x00000008, 0x41),
                (0x00000009, 0x56),
                (0x0000000a, 0x49),
                (0x0000000b, 0x20),

                (0x0000000c, 0x4c),
                (0x0000000d, 0x49),
                (0x0000000e, 0x53),
                (0x0000000f, 0x54),

                (0x00000014, 0x68),
                (0x00000015, 0x64),
                (0x00000016, 0x72),
                (0x00000017, 0x6c),

                (0x00000018, 0x61),
                (0x00000019, 0x76),
                (0x0000001a, 0x69),
                (0x0000001b, 0x68),

                (0x00000058, 0x4c),
                (0x00000059, 0x49),
                (0x0000005a, 0x53),
                (0x0000005b, 0x54),

                (0x00000060, 0x73),
                (0x00000061, 0x74),
                (0x00000062, 0x72),
                (0x00000063, 0x6c),

                (0x00000064, 0x73),
                (0x00000065, 0x74),
                (0x00000066, 0x72),
                (0x00000067, 0x68),

                (0x0000006c, 0x76),
                (0x0000006d, 0x69),
                (0x0000006e, 0x64),
                (0x0000006f, 0x73),

                (0x00000070, 0x46),
                (0x00000071, 0x4d),
                (0x00000072, 0x50),
                (0x00000073, 0x34),

                (0x000000a4, 0x73),
                (0x000000a5, 0x74),
                (0x000000a6, 0x72),
                (0x000000a7, 0x66),

                (0x000000bc, 0x46),
                (0x000000bd, 0x4d),
                (0x000000be, 0x50),
                (0x000000bf, 0x34),

                (0x000000d4, 0x4a),
                (0x000000d5, 0x55),
                (0x000000d6, 0x4e),
                (0x000000d7, 0x4b),

                (0x000010f4, 0x4a),
                (0x000010f5, 0x55),
                (0x000010f6, 0x4e),
                (0x000010f7, 0x4b),

                (0x00001200, 0x4c),
                (0x00001201, 0x49),
                (0x00001202, 0x53),
                (0x00001203, 0x54),

                (0x00002000, 0x4c),
                (0x00002001, 0x49),
                (0x00002002, 0x53),
                (0x00002003, 0x54),

                (0x00002008, 0x6d),
                (0x00002009, 0x6f),
                (0x0000200a, 0x76),
                (0x0000200b, 0x69),
            });
        }
    }

    private static void ListAviFiles(string path, ref List<string> files)
    {
        try
        {
            // Get all .avi files in the current directory
            foreach (string file in Directory.GetFiles(path, "*.avi"))
            {
                files.Add(file);
            }

            // Recurse into subdirectories
            foreach (string directory in Directory.GetDirectories(path))
            {
                ListAviFiles(directory, ref files);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Access denied to {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accessing {path}: {ex.Message}");
        }
    }

    private static void ReplaceBytes(string path, (long position, byte newValue)[] modifications)
    {
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                foreach (var modification in modifications)
                {
                    if (modification.position < fs.Length)
                    {
                        fs.Seek(modification.position, SeekOrigin.Begin);
                        fs.WriteByte(modification.newValue);
                    }
                    else
                    {
                        Console.WriteLine($"Position {modification.position} is out of bounds for file '{path}'.");
                    }
                }
            }

            Console.WriteLine($"Modifications applied to '{path}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error modifying file: {ex.Message}");
        }
    }
}