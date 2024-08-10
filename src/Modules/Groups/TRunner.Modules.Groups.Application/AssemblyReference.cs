using System.Reflection;

namespace TRunner.Modules.Groups.Application;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
