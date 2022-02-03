using System.CommandLine;
using System.CommandLine.DragonFruit;
using System.IO;
using System;

namespace ejector{

    public static class Eject{
        static bool _v = false;

        /// <summary>
        /// Removable device ejector command-line utility
        /// </summary>
        /// <param name="d">Device letter to eject</param>
        /// <param name="v">Verbose mode</param>
        /// <param name="ls">List removable drives</param>
        public static void Main(string d = "", bool v = false, bool ls = false){
            if (ls){
                var drive_list = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable);
                if (drive_list.Count() == 0){
                    Console.WriteLine("No removable drives detected."); return;
                }

                int c = 0;
                foreach (DriveInfo info in drive_list){
                    c++;
                    Console.WriteLine($"{c}. {info.Name}  {info.VolumeLabel}");
                }
                return;
            }
            _v = v;
            DebugPrint($"Device letter: {d}");
            if (string.IsNullOrEmpty(d)){ // no device letter
                Console.WriteLine($"Must provide device letter. ( -d DEVICELETTER )");
            }
            if (d.Length >1){ // invalid device letter
                Console.WriteLine($"Invalid device letter! {d}");
            }
            try{
                if (IO.Eject(IO.USBEject(d)))
                    DebugPrint($"Successfully ejected {d}");
                else
                    DebugPrint($"Failed to eject {d}");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

        public static void DebugPrint(string _str){
            if (!_v) return;
            Console.WriteLine(_str);
        }
    }
}