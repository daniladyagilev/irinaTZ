using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Native
{
    class NativeFunctions
    {
        public static void Multiplication()
        {

            string assemblyName = "Multiplication";
            string modName = "Multiplication.dll";
            string typeName = "MultiplicationDLL";

            AssemblyName name = new AssemblyName(assemblyName);
            AppDomain domain = System.Threading.Thread.GetDomain();
            AssemblyBuilder builder = domain.DefineDynamicAssembly(
              name, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder module = builder.DefineDynamicModule
              (modName, true);

            TypeBuilder typeBuilder = module.DefineType(typeName,
              TypeAttributes.Public);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "Multiplication",
                MethodAttributes.Public,
                typeof(int),
                new Type[] { typeof(int), typeof(int) }
                );

            ILGenerator iLGenerator = methodBuilder.GetILGenerator();

            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Ldarg_2);
            iLGenerator.Emit(OpCodes.Mul_Ovf_Un);
            iLGenerator.Emit(OpCodes.Ret);

            typeBuilder.CreateType();

            builder.Save(assemblyName + ".dll");

        }
        public static void Main(string[] args)
        {
            Multiplication();
        }
    }
}