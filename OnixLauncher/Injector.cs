using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static OnixLauncher.Winapi;

namespace OnixLauncher
{
    public static class Injector // this is the part that makes your antivirus go mad
    {
        public static EventHandler<EventArgs> InjectionCompleted;

        public static void Inject(string path)
        {
            try
            {
                Utils.OpenGame();
                Thread.Sleep(TimeSpan.FromSeconds(5));

                ApplyAppPackages(path);

                var targetProcess = Process.GetProcessesByName("Minecraft.Windows")[0];

                var procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION |
                                             PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ,
                    false, targetProcess.Id);

                var loadLibraryAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                var allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero,
                    (uint) ((path.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT
                                                                               | MEM_RESERVE, PAGE_READWRITE);

                WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(path),
                    (uint) ((path.Length + 1) * Marshal.SizeOf(typeof(char))), out _);
                CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddress,
                    allocMemAddress, 0, IntPtr.Zero);
                
                InjectionCompleted.Invoke(null, EventArgs.Empty);
                
                Utils.ShowMessage("Finished", "Onix Client was successfully launched.");
            }
            catch
            {
                Utils.ShowMessage("Injection Error", "Something weird happened while injecting.");
                InjectionCompleted.Invoke(null, EventArgs.Empty);
            }
        }
        
        private static void ApplyAppPackages(string path)
        {
            var infoFile = new FileInfo(path);
            var fSecurity = infoFile.GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), 
                FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            infoFile.SetAccessControl(fSecurity);
        }
    }
}