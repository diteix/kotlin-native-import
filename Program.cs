using System;
using System.Runtime.InteropServices;

namespace TesteKotlinNative
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr p = NativeMethods.BarSymbols();
            ExportedSymbols es = (ExportedSymbols)Marshal.PtrToStructure(p, typeof(ExportedSymbols));
            var helloWorldFromKotlin = Marshal.PtrToStringAnsi(es.FuncHello());

            Console.WriteLine(helloWorldFromKotlin);
            Console.ReadKey();
        }
    }

    public class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisposeStablePointer(IntPtr ptr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisposeString([MarshalAs(UnmanagedType.LPStr)] string str);

        // this assumes that bar_KBoolean is defined as an int
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool IsInstance(IntPtr @ref, IntPtr type);

        public delegate IntPtr hello();

        [DllImport("Kotlin/dynamic.dll", EntryPoint = "dynamic_symbols")]
        public static extern IntPtr BarSymbols();
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ExportedSymbols
    {
        public NativeMethods.DisposeStablePointer FuncPointerDispose;
        public NativeMethods.DisposeString FuncStringDispose;
        public NativeMethods.IsInstance FuncIsInstance;
        public NativeMethods.hello FuncHello;
    }
}
