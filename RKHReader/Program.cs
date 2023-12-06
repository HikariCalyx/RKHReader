namespace RKHReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 || !(File.Exists(args[0]) || Directory.Exists(args[0])))
            {
                Console.WriteLine("Usage: <Path to Qualcomm Signed file>");
            }

            if (File.Exists(args[0]))
            {
                PrintRKHFromFile(args[0]);
            }

            if (Directory.Exists(args[0]))
            {
                foreach (var el in Directory.EnumerateFiles(args[0], "*.*", SearchOption.AllDirectories))
                {
                    PrintRKHFromFile(el);
                }
            }
        }

        static void PrintRKHFromFile(string file)
        {
            try
            {
                QualcommPartition qualcommPartition = new(file);
                if (qualcommPartition.RootKeyHash != null)
                {
                    Console.WriteLine(file);
                    Console.WriteLine("RKH: " + Converter.ConvertHexToString(qualcommPartition.RootKeyHash, ""));
                    if (Converter.ConvertHexToString(qualcommPartition.RootKeyHash, "") == "959B8D0549EF41BEFABC24F51EFE84FEE366AC169AB04A0DB30C799B324FD798")
                    {
                        Console.WriteLine("WARNING: This image has Qualcomm Generic Test Signature! ");
                    }
                }
                else
                {
                    Console.WriteLine(file);
                    Console.WriteLine("FAIL!");
                }
            } catch (Exception e)
            {
                Console.WriteLine(file);
                Console.WriteLine("EXCEPTION!");
                Console.WriteLine(e);
            }
        }
    }
}