using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    class Memory
    {

        public static bool connected { get; set; }

        public static Offsets offsets = new Offsets();

        public const int PROCESS_WM_READ = 0x0010;
        public const int PROCESS_VM_WRITE = 0x0020;
        public const int PROCESS_VM_OPERATION = 0x0008;
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        public static byte[] ReadBytes(int address, int length)
        {
            byte[] bytes = new byte[length];
            Process process = new Process();
            try
            {
                process = Process.GetProcessesByName("sonic2app")[0];

                IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);

                int bytesRead = 0;

                ReadProcessMemory((int)processHandle, address, bytes, length, ref bytesRead);

                connected = true;
            }
            catch
            {
                MessageBox.Show("Couldn't read from Sonic Adventure 2 Process.", "Error reading from process", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connected = false;
            }

            return bytes;
        }

        public static void WriteByteAtAddress(int address, byte toWrite)
        {
            Process process = new Process();
            try
            {
                process = Process.GetProcessesByName("sonic2app")[0];

                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);

                int bytesWritten = 0;

                byte[] toWriteArray = new byte[1];

                toWriteArray[0] = toWrite;

                WriteProcessMemory((int)processHandle, address, toWriteArray, toWriteArray.Length, ref bytesWritten);
                connected = true;
            }
            catch
            {
                MessageBox.Show("Couldn't write to Sonic Adventure 2 Process.", "Error writing to process", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connected = false;
            }
        }

        public static void WriteBytesAtAddress(int address, byte[] toWrite)
        {
            Process process = new Process();
            try
            {
                process = Process.GetProcessesByName("sonic2app")[0];

                IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);

                int bytesWritten = 0;

                WriteProcessMemory((int)processHandle, address, toWrite, toWrite.Length, ref bytesWritten);
                connected = true;
            }
            catch
            {
                MessageBox.Show("Couldn't write to Sonic Adventure 2 Process.", "Error writing to process", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connected = false;
            }
        }
    }
}
