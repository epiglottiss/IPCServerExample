// See https://aka.ms/new-console-template for more information
using System.IO.MemoryMappedFiles;

Console.WriteLine("Hello, World!");

MemoryMappedFile? mapFile = null;
try
{
    mapFile = MemoryMappedFile.CreateNew("name", 64, MemoryMappedFileAccess.ReadWrite);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

MemoryMappedViewAccessor? accesor = null;
try
{
    accesor = mapFile?.CreateViewAccessor();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

char[] procName = "proc".ToCharArray();
File file = new File { pid = 123, currentValue = 50, /*processName = procName,*/ warrningLimit = 40 };

accesor?.Write<File>(0, ref file);

while (true)
{
    if(Console.ReadLine() == "q")
    {
        break;
    }
}


struct File
{
    public int pid;
    public char processName;
    public int currentValue;
    public int warrningLimit;
}