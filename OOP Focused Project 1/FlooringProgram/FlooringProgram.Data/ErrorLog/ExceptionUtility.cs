using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data.ErrorLog
{
    public sealed class ExceptionUtility
    {
        public static List<string> ErrorsLog { get; private set; }

        private ExceptionUtility()
        {
            ErrorsLog = new List<string>();
        }

        // Logging Exceptions/Errors
        public static void LogErrors(Exception ex, string source)
        {
            string LOGFILE = @"C:\Users\Apprentice\Desktop\_Repository\jeannine-james-individual-work\FlooringProgram\FlooringProgram.Data\ErrorLog\errorLog.txt";
            using (StreamWriter sw = new StreamWriter(LOGFILE, false))
            {
                sw.WriteLine($"**********************************");
                sw.WriteLine($"*****************{DateTime.Now}*****************");
                sw.WriteLine($"**********************************");

                if (ex.InnerException != null)
                {
                    sw.Write("Inner Exception Type: ");
                    sw.WriteLine(ex.InnerException.GetType().ToString());
                    sw.Write("Inner Exception: ");
                    sw.WriteLine(ex.InnerException.Message);
                    sw.Write("Source of inner exception: ");
                    sw.WriteLine(ex.InnerException.Source);

                    if (ex.InnerException.StackTrace != null)
                    {
                        sw.WriteLine("Inner stack trace: ");
                        sw.WriteLine(ex.InnerException.StackTrace);
                    }
                }
                else
                {
                    sw.Write("Exception Type: ");
                    sw.WriteLine(ex.GetType().ToString());
                    sw.WriteLine($"Exception: {ex.Message}");
                    sw.WriteLine($"Source: {source}");
                    if (ex.StackTrace != null)
                    {
                        sw.WriteLine("Stack trace: ");
                        sw.WriteLine(ex.StackTrace);
                        sw.WriteLine();
                    }
                }
            }
        }

        public static void LogErrors(string message)
        {
            string LOGFILE = @"C:\Users\Apprentice\Desktop\_Repository\jeannine-james-individual-work\FlooringProgram\FlooringProgram.Data\ErrorLog\errorLog.txt";

           // ErrorsLog.Add(message);
            using (StreamWriter sw = File.AppendText(LOGFILE))
            {

                sw.WriteLine($"**********************************");
                sw.WriteLine($"*****{DateTime.Now}**********");
                sw.WriteLine($"**********************************");
                sw.WriteLine(message);
                }
                
            }
        }
    }

