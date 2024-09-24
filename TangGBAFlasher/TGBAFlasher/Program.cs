// (C) 2024 PeevishDave. Peevo.art

namespace TGBAFlasher;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(new GBAFlasher()));
    }    
}