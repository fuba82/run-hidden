
using System;
using System.Diagnostics;
using System.Linq;

namespace run_hidden
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length != 0)
             {
                using (Process p = new Process())
                {
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(args[0]);

                    args = args.Skip(1).ToArray();

                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i] = Environment.ExpandEnvironmentVariables(args[i]);
                        if (args[i].Contains(" "))
                        {
                            args[i] = "\"" + args[i] + "\"";
                        }
                    }

                    p.StartInfo.Arguments = string.Join(" ", args);
                    p.Start();
                    Environment.ExitCode = 0;
                }
            }
        }
    }
}
