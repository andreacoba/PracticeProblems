using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programs
{
    class Program
    {
        enum runRequests { MergeRanges };

        static void Main(string[] args)
        {
            if(args.Length == 0) {
                StringBuilder sb = new StringBuilder();
                foreach(var o in Enum.GetNames(typeof(runRequests)))
                {
                    sb.AppendLine($"({(int)Enum.Parse(typeof(runRequests), o)}) {o}");
                }

                Console.WriteLine($"Specify which program to run, type the int value for it:");
                Console.WriteLine(sb.ToString());
            }
            else 
            {
                if(args[0].Equals(((int)runRequests.MergeRanges).ToString()))
                {
                    MergeRanges.DoMergeRanges();    
                }    
            }            
        }
    }
}
