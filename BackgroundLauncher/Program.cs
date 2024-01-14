using System.Diagnostics;

namespace BackgroundLauncher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error, first argument must specify path to executable");
            }

            string executable = args[0];

            IEnumerable<string>? newArgs = args.Skip(1);

            Run(executable, newArgs);
        }

        public static void Run(string executable, IEnumerable<string>? args = default)
        {
            Process process = new Process();

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            process.StartInfo.FileName = executable;

            if (args is not null)
                process.StartInfo.Arguments = string.Join("", args);

            process.Start();
        }
    }
}
