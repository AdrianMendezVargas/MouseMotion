using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetCursorPos(out POINT lpPoint);

    const int MOUSEEVENTF_LEFTDOWN = 0x02;
    const int MOUSEEVENTF_LEFTUP = 0x04;

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    static void Main(string[] args)
    {
        // Crear un temporizador que se ejecute cada 15 minutos
        Timer timer = new Timer(MoveAndClickMouse, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));

        // Mantener el programa en ejecución
        Console.WriteLine("El programa está en ejecución. Presiona cualquier tecla para salir.");
        Console.ReadKey();

        // Detener el temporizador antes de salir
        timer.Dispose();
    }

    static void MoveAndClickMouse(object state)
    {
        // Obtener la posición actual del mouse
        GetCursorPos(out POINT currentPosition);

        // Mover el mouse a la posición inicial
        SetCursorPos(10, 500);

        // Simular un clic izquierdo del mouse
        //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, currentPosition.X, currentPosition.Y, 0, 0);
    }
}
