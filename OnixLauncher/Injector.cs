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
            Log.Write("Injecting " + path);
            try
            {
                Utils.OpenGame();
                Log.Write("Waiting 5 seconds to allow the game to load");
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
                
                Log.Write("Finished injecting");
            }
            catch (Exception e)
            {
                Log.Write("Injection failed, the user's antivirus is probably the cause. Exception: " + e.Message);
                Utils.ShowMessage("Injection Error", "Failed to inject. Try disabling your antivirus.");
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
            Log.Write("Applied ALL_APPLICATION_PACKAGES permission to " + path);
        }
    }
}